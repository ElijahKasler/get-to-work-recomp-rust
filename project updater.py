#!/usr/bin/env python3
"""Project Updater — safe paste-based project editor (Python 3.8+)."""
from pathlib import Path
import json, os, re, shutil, time, fnmatch
import tkinter as tk
from tkinter import ttk, filedialog, messagebox
from tkinter.scrolledtext import ScrolledText

BACKUP_DIR = ".paste-backup"
CONFIG = Path.home() / ".project_updater.json"
SKIP_DIRS = {".git", BACKUP_DIR, "target", "node_modules", "dist", "__pycache__", ".venv"}
MAX_HITS = 300

class PatchError(Exception):
    pass

def norm(s):
    return s.replace("\r\n", "\n").replace("\r", "\n")

def safe_path(root, rel, allow_root=False):
    rel = rel.strip().strip('"').replace("\\", "/")
    if allow_root and rel in ("", ".", "./"):
        return root.resolve()
    if not rel or rel.startswith("/") or re.match(r"^[A-Za-z]:", rel):
        raise PatchError(f"Invalid/absolute path: {rel!r}")
    full = (root.resolve() / rel).resolve()
    try:
        parts = full.relative_to(root.resolve()).parts
    except ValueError:
        raise PatchError(f"Path leaves the project folder: {rel}")
    if not parts or BACKUP_DIR in parts or ".git" in parts:
        raise PatchError(f"Path is off limits: {rel}")
    return full

def read_alias(line):
    line = line.strip()
    if line.startswith("===") and line.endswith("==="):
        line = line[3:-3].strip()
    m = re.match(r"^GREP\s+(['\"])(.*?)\1\s+in\s+(.+)$", line, re.I)
    if m: return {"kind":"GREP", "path":m.group(3).strip().strip('"'), "body":[m.group(2)]}
    m = re.match(r"^READ\s+(.+?)(?:\s+lines\s+(\d+\s*-\s*\d+))?$", line, re.I)
    if m: return {"kind":"READ", "path":m.group(1).strip().strip('"'), "body":["lines "+m.group(2)] if m.group(2) else []}
    m = re.match(r"^LIST\s+(.+?)(?:\s+depth\s+(\d+))?$", line, re.I)
    if m: return {"kind":"LIST", "path":m.group(1).strip().strip('"'), "body":["depth "+m.group(2)] if m.group(2) else []}
    return None

def parse(text):
    ops, cur = [], None
    start_re = re.compile(r"^===\s*(FILE|REPLACE|APPEND|DELETE|READ|GREP|LIST)\s*:\s*(.+?)\s*===\s*$")
    for line in norm(text).split("\n"):
        if cur is None:
            m = start_re.match(line)
            if m:
                cur = {"kind":m.group(1), "path":m.group(2).strip().strip('"'), "body":[]}
            else:
                alias = read_alias(line)
                if alias: ops.append(alias)
            continue
        if re.match(r"^===\s*END\s*===\s*$", line):
            ops.append(cur); cur = None
        else: cur["body"].append(line)
    if cur is not None: raise PatchError(f"Block for {cur['path']} is missing === END ===")
    return ops

def strip_fence(lines):
    while lines and not lines[0].strip(): lines.pop(0)
    while lines and not lines[-1].strip(): lines.pop()
    if len(lines) >= 2 and lines[0].strip().startswith("```") and lines[-1].strip() == "```":
        return lines[1:-1]
    return lines

def find_unique(text, old, path):
    first = text.find(old)
    if first >= 0:
        if text.find(old, first + 1) >= 0: raise PatchError(f"REPLACE in {path}: FIND text matches multiple places; add context.\n---\n{old}")
        return first, first + len(old)
    tl, ol = text.split("\n"), [x.rstrip() for x in old.split("\n")]
    hits = [i for i in range(len(tl)-len(ol)+1) if [x.rstrip() for x in tl[i:i+len(ol)]] == ol]
    if len(hits) == 1:
        i = hits[0]; a = sum(len(x)+1 for x in tl[:i]); b = a + sum(len(x)+1 for x in tl[i:i+len(ol)]) - 1
        return a, b
    if len(hits) > 1: raise PatchError(f"REPLACE in {path}: FIND text matches multiple places; add context.\n---\n{old}")
    raise PatchError(f"REPLACE in {path}: FIND text was not found. No changes were made.\n---\n{old}")

def read_text_file(path):
    data = path.read_bytes()
    if b"\0" in data[:8192]: raise PatchError(f"Not a text file: {path}")
    return data.decode("utf-8", errors="replace")

def walk(base):
    if base.is_file():
        yield base; return
    for dp, dns, fns in os.walk(base):
        dns[:] = sorted(d for d in dns if d not in SKIP_DIRS)
        for name in sorted(fns): yield Path(dp) / name

def option(body, name):
    for line in body:
        m = re.match(rf"^\s*{name}\s*[: ]\s*(.+?)\s*$", line, re.I)
        if m: return m.group(1)
    return None

def do_read(root, op):
    path = safe_path(root, op["path"], allow_root=True)
    kind = op["kind"]
    if kind == "READ":
        if not path.is_file(): raise PatchError(f"READ: not a file: {op['path']}")
        lines = norm(read_text_file(path)).split("\n"); total = len(lines); start, end = 1, total
        rg = option(op["body"], "lines")
        if rg:
            m = re.match(r"^(\d+)\s*-\s*(\d+)$", rg)
            if not m: raise PatchError("READ range should look like: lines 10-80")
            start, end = max(1, int(m.group(1))), min(total, int(m.group(2)))
        return f"##### {op['path']} (lines {start}-{end} of {total})\n" + "\n".join(lines[start-1:end]) + f"\n##### end {op['path']}"
    if kind == "LIST":
        if not path.is_dir(): raise PatchError(f"LIST: not a folder: {op['path']}")
        depth = int(option(op["body"], "depth") or 2); out=[]
        def rec(d, level):
            if len(out) >= 600: return
            for p in sorted(d.iterdir(), key=lambda x:(not x.is_dir(), x.name.lower())):
                if p.is_dir() and p.name in SKIP_DIRS: continue
                out.append("  "*level + p.name + ("/" if p.is_dir() else ""))
                if p.is_dir() and level+1 < depth: rec(p, level+1)
                if len(out) >= 600: break
        rec(path, 0)
        return f"##### LIST {op['path']} (depth {depth})\n" + "\n".join(out)
    pattern = next((x.strip() for x in op["body"] if x.strip() and not re.match(r"^glob\s*[: ]",x,re.I)), "")
    if not pattern: raise PatchError("GREP: provide a regex pattern")
    try: rx = re.compile(pattern)
    except re.error as e: raise PatchError(f"Invalid GREP regex: {e}")
    globs = [x.strip() for x in (option(op["body"], "glob") or "").split(",") if x.strip()]
    hits=[]; seen=0
    for f in walk(path):
        if globs and not any(fnmatch.fnmatch(f.name,g) for g in globs): continue
        try: txt=read_text_file(f)
        except (OSError, PatchError): continue
        seen += 1
        for i,line in enumerate(norm(txt).split("\n"),1):
            if rx.search(line):
                try: rel=f.resolve().relative_to(root.resolve()).as_posix()
                except ValueError: rel=str(f)
                hits.append(f"{rel}:{i}: {line.strip()[:300]}")
                if len(hits)>=MAX_HITS: break
        if len(hits)>=MAX_HITS: break
    return f"##### GREP '{pattern}' in {op['path']} ({len(hits)} matches, {seen} files searched)\n" + ("\n".join(hits) if hits else "(no matches)")

def run(root, paste, save_as="", preview=False):
    root = Path(root)
    if not root.is_dir(): raise PatchError("Choose a valid project folder first.")
    if not paste.strip(): raise PatchError("The paste box is empty.")
    ops = parse(paste)
    if not ops:
        if not save_as.strip(): raise PatchError("No file blocks found. Use === FILE: path === ... === END ===, or fill in Save as.")
        ops=[{"kind":"FILE","path":save_as.strip(),"body":strip_fence(norm(paste).split("\n"))}]
    outputs=[]
    for op in ops:
        if op["kind"] in ("READ","GREP","LIST"):
            try: outputs.append(do_read(root,op))
            except Exception as e: outputs.append(f"##### ERROR in {op['kind']} {op['path']}: {e}")
    writes=[o for o in ops if o["kind"] not in ("READ","GREP","LIST")]
    if not writes: return [], None, "\n\n".join(outputs)
    planned={}; report=[]
    def entry(rel):
        full=safe_path(root,rel); key=str(full).casefold()
        if key not in planned:
            existed=full.is_file(); raw=full.read_bytes() if existed else b""
            eol="\r\n" if b"\r\n" in raw else "\n"
            try: txt=raw.decode("utf-8").replace("\r\n","\n") if existed else ""
            except UnicodeDecodeError: raise PatchError(f"Not a UTF-8 text file: {rel}")
            planned[key]={"path":rel.replace("\\","/"),"full":full,"existed":existed,"original":raw,"text":txt,"eol":eol,"delete":False}
        return planned[key]
    for op in writes:
        kind, rel=op["kind"],op["path"]; e=entry(rel); body=strip_fence(op["body"])
        if kind=="FILE": e["text"]="\n".join(body)+("\n" if body else ""); e["delete"]=False; report.append(("write/replace",rel))
        elif kind=="APPEND":
            if e["text"] and not e["text"].endswith("\n"): e["text"]+="\n"
            e["text"] += "\n".join(body)+"\n"; e["delete"]=False; report.append(("append",rel))
        elif kind=="DELETE":
            if not e["existed"]: raise PatchError(f"DELETE: file does not exist: {rel}")
            e["delete"]=True; report.append(("delete",rel))
        elif kind=="REPLACE":
            mode=None; old=[]; new=[]; pairs=0
            for line in op["body"]:
                if line.strip()=="<<<<<<< FIND": mode="find"; old=[]; new=[]
                elif line.strip()=="=======" and mode=="find": mode="repl"
                elif line.strip()==">>>>>>> REPLACE" and mode=="repl":
                    a,b=find_unique(e["text"],"\n".join(old),rel); e["text"]=e["text"][:a]+"\n".join(new)+e["text"][b:]; mode=None; pairs+=1
                elif mode=="find": old.append(line)
                elif mode=="repl": new.append(line)
            if mode is not None or pairs==0: raise PatchError(f"REPLACE in {rel}: malformed or missing FIND/REPLACE markers")
            e["delete"]=False; report.append((f"replace x{pairs}",rel))
        else: raise PatchError(f"Unknown operation: {kind}")
    if preview: return report,None,"\n\n".join(outputs)
    stamp=time.strftime("%Y%m%d-%H%M%S"); backup=root/BACKUP_DIR/stamp; n=1
    while backup.exists(): n+=1; backup=root/BACKUP_DIR/f"{stamp}-{n}"
    (backup/"files").mkdir(parents=True); manifest=[]
    for e in planned.values():
        manifest.append({"path":e["path"],"existed":e["existed"],"delete":e["delete"]})
        if e["existed"]:
            dest=backup/"files"/e["path"]; dest.parent.mkdir(parents=True,exist_ok=True); shutil.copy2(e["full"],dest)
    (backup/"manifest.json").write_text(json.dumps(manifest,indent=2),encoding="utf-8")
    for e in planned.values():
        if e["delete"]:
            if e["full"].exists(): e["full"].unlink()
        else:
            e["full"].parent.mkdir(parents=True,exist_ok=True)
            e["full"].write_bytes(e["text"].replace("\n",e["eol"]).encode("utf-8"))
    return report,backup.name,"\n\n".join(outputs)

def undo(root):
    base=Path(root)/BACKUP_DIR
    runs=sorted(p for p in base.iterdir() if p.is_dir()) if base.is_dir() else []
    if not runs: raise PatchError("No backup is available to undo.")
    b=runs[-1]; manifest=json.loads((b/"manifest.json").read_text(encoding="utf-8")); done=[]
    for item in manifest:
        full=safe_path(Path(root),item["path"])
        if item["existed"]:
            src=b/"files"/item["path"]; full.parent.mkdir(parents=True,exist_ok=True); shutil.copy2(src,full); done.append("restored "+item["path"])
        elif full.exists(): full.unlink(); done.append("removed "+item["path"])
    shutil.rmtree(b); return b.name,done

def main():
    try: cfg=json.loads(CONFIG.read_text(encoding="utf-8"))
    except Exception: cfg={}
    win=tk.Tk(); win.title("Project Updater"); win.geometry("950x850"); win.minsize(680,550)
    folder=tk.StringVar(value=cfg.get("folder","")); save_as=tk.StringVar(); autocopy=tk.BooleanVar(value=True); clear=tk.BooleanVar(value=False)
    outer=ttk.Frame(win,padding=8); outer.pack(fill="both",expand=True)
    row=ttk.Frame(outer); row.pack(fill="x")
    ttk.Label(row,text="Project folder:").pack(side="left")
    ttk.Entry(row,textvariable=folder).pack(side="left",fill="x",expand=True,padx=6)
    def choose():
        p=filedialog.askdirectory(initialdir=folder.get() or str(Path.home()))
        if p: folder.set(p); savecfg()
    def savecfg():
        try: CONFIG.write_text(json.dumps({"folder":folder.get()}),encoding="utf-8")
        except OSError: pass
    ttk.Button(row,text="Browse...",command=choose).pack(side="left")
    def openfolder():
        p=folder.get().strip()
        if p and Path(p).is_dir():
            if os.name=="nt": os.startfile(p)
            else: messagebox.showinfo("Project folder",p)
    ttk.Button(row,text="Open",command=openfolder).pack(side="left",padx=5)
    ttk.Label(outer,text="Paste updater commands or patch blocks:").pack(anchor="w",pady=(8,2))
    paste=ScrolledText(outer,height=15,undo=True,wrap="none",font=("Consolas",10)); paste.pack(fill="both",expand=True)
    row2=ttk.Frame(outer); row2.pack(fill="x",pady=5)
    ttk.Label(row2,text="Save as (for plain file contents only):").pack(side="left")
    ttk.Entry(row2,textvariable=save_as).pack(side="left",fill="x",expand=True,padx=6)
    ttk.Label(outer,text="Output (READ / GREP / LIST):").pack(anchor="w")
    out=ScrolledText(outer,height=9,wrap="none",font=("Consolas",9)); out.pack(fill="both",expand=True)
    ttk.Label(outer,text="Activity log:").pack(anchor="w")
    log=ScrolledText(outer,height=6,state="disabled",font=("Consolas",9)); log.pack(fill="both",expand=True)
    def say(s): log.configure(state="normal"); log.insert("end",s+"\n"); log.see("end"); log.configure(state="disabled")
    def root():
        p=folder.get().strip()
        if not p: raise PatchError("Choose the project folder first.")
        if not Path(p).is_dir(): raise PatchError("Project folder does not exist.")
        savecfg(); return Path(p)
    def apply(preview=False):
        try: report,backup,output=run(root(),paste.get("1.0","end"),save_as.get(),preview)
        except Exception as e: say(f"ERROR (nothing was changed): {e}"); return
        if output:
            out.delete("1.0","end"); out.insert("1.0",output)
            if autocopy.get():
                try: win.clipboard_clear(); win.clipboard_append(output); say("Read output copied to clipboard.")
                except tk.TclError: say("Output is shown above; clipboard copy failed.")
        for action,path in report: say(f"{action}: {path}")
        if preview: say("Preview complete — no files changed.")
        elif backup: say(f"Applied. Backup: {BACKUP_DIR}/{backup}")
        elif output: say("Read-only operation complete; no files changed.")
        if clear.get() and not preview: paste.delete("1.0","end")
    def apply_confirm():
        if re.search(r"^===\s*DELETE\s*:",paste.get("1.0","end"),re.M) and not messagebox.askyesno("Confirm delete","This patch deletes files. Continue?"): return
        apply(False)
    def paste_clip(run_now=False):
        try: data=win.clipboard_get()
        except tk.TclError: say("Clipboard has no text."); return
        paste.delete("1.0","end"); paste.insert("1.0",data)
        if run_now: apply_confirm()
    def do_undo():
        try: name,items=undo(root()); say("Undid "+name); [say(x) for x in items]
        except Exception as e: say("UNDO ERROR: "+str(e))
    buttons=ttk.Frame(outer); buttons.pack(fill="x",pady=6)
    ttk.Button(buttons,text="Paste && Apply",command=lambda:paste_clip(True)).pack(side="left")
    ttk.Button(buttons,text="Paste only",command=lambda:paste_clip(False)).pack(side="left",padx=4)
    ttk.Button(buttons,text="Preview",command=lambda:apply(True)).pack(side="left",padx=4)
    ttk.Button(buttons,text="Apply box",command=apply_confirm).pack(side="left",padx=4)
    ttk.Button(buttons,text="Undo last",command=do_undo).pack(side="left",padx=4)
    ttk.Button(buttons,text="Copy output",command=lambda:(win.clipboard_clear(),win.clipboard_append(out.get("1.0","end").strip()))).pack(side="left",padx=4)
    ttk.Button(buttons,text="Clear",command=lambda:paste.delete("1.0","end")).pack(side="left",padx=4)
    ttk.Checkbutton(buttons,text="Auto-copy output",variable=autocopy).pack(side="right")
    ttk.Checkbutton(buttons,text="Clear after apply",variable=clear).pack(side="right",padx=8)
    win.bind("<Control-Return>",lambda e:apply_confirm())
    say("Select your project folder, paste a command/block, then click Apply box.")
    say("Read-only aliases: GREP 'pattern' in path/to/file | READ path/to/file | LIST path/to/folder")
    say("Block commands: === FILE: path ===, === REPLACE: path ===, === APPEND: path ===, === DELETE: path ===")
    say("Every write is backed up. Use Undo last to reverse the latest applied patch.")
    win.mainloop()

if __name__ == "__main__": main()
