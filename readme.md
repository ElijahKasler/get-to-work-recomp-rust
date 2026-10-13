# MASTER PROMPT — GET TO WORK: COMPLETE 1:1 UNITY → RUST/BEVY REIMPLEMENTATION

## 1. Mission

You are the lead game-engine developer responsible for rebuilding the entire Unity game **Get to Work** as a native Rust game using Bevy.

I have restarted the project from scratch. Do not assume that any previous Rust implementation exists or that previous progress claims are still accurate.

Your objective is to reproduce the original game as faithfully as possible, using the actual source files, decompiled C# scripts, Unity assets, configuration data, and middleware information I provide.

**The goal is the complete game, not a prototype, demo, mockup, or logic-only port.**

The intended final result includes:

- All original gameplay mechanics and player controls.
- All levels, scenes, checkpoints, triggers, and progression.
- Original player movement, physics, ragdoll, animation, and inverse kinematics.
- Original game objects, environmental interactions, and hazards.
- Menus, HUD, settings, dialogue, subtitles, and localization.
- Audio, music, effects, and spatial sound.
- Camera behavior and transitions.
- Save/load, achievements, leaderboards, and progression systems.
- Meshes, materials, textures, animations, shaders, lighting, and environmental effects.
- The appropriate replacement for every required Unity or middleware runtime feature.
- A reliable native executable that can be built and launched on Windows.

Do not declare the project complete merely because it compiles or because every C# file has a corresponding Rust file.

## 2. Source and destination

Use the actual paths available on this machine. Start by inspecting the filesystem and locating the supplied project rather than assuming that a previous folder structure still exists.

Previous known locations, which must be verified:

Original project and assets:
`D:\Web Ports\Get To Work\`

Previously identified source project:
`D:\Web Ports\Get To Work\Get to Work Project\`

Previously identified Rust destination:
`D:\Web Ports\Get To Work\rustg2w\`

The original Unity assets may be supplied in a separate `Assets` directory, archive, or exported project. Locate the actual supplied files.

If the original decompiled scripts are available, locate:

`Assets\Scripts\Assembly-CSharp\`

If the Unity asset path map exists, locate:

`AuxiliaryFiles\path_id_map.json`

These are examples of the previous structure, not guaranteed current paths.

### Mandatory filesystem rules

1. Identify the actual asset root, source root, and destination root before editing.
2. Never modify, delete, rename, or overwrite original source or asset files.
3. Keep all generated code, converted assets, caches, logs, and documentation inside the new destination project or its explicitly configured generated-data directory.
4. Never assume an asset is absent until the relevant directories and archives have been checked.
5. Never silently replace missing assets with fabricated equivalents.
6. Preserve the original assets and their metadata wherever practical.
7. If the supplied material is incomplete, document exactly what is missing and continue with independent tasks.

## 3. First task: audit the supplied project

Before writing substantial code, create a factual inventory.

Inspect:

- All C# scripts and their namespaces.
- Script inheritance, interfaces, fields, serialized defaults, events, and lifecycle methods.
- Scenes and their GameObject/component hierarchies.
- Meshes, vertex layouts, indices, normals, tangents, UVs, and skinning information.
- Textures, texture formats, dimensions, and import settings.
- Materials, shaders, render queues, and shader properties.
- Animation clips, animator controllers, avatars, and rig definitions.
- Physics materials, rigidbodies, colliders, joints, triggers, and layers.
- Audio clips, FMOD banks, event paths, mixers, and music definitions.
- Prefabs, ScriptableObjects, Resources, and Addressables.
- Input mappings and controller configuration.
- Cinemachine settings, post-processing, fog, lighting, and rendering settings.
- Localization tables, dialogue assets, UI layouts, and fonts.
- Middleware DLLs, versions, APIs, and configuration files.
- Build settings, scene order, game startup flow, and platform-specific behavior.
- All asset GUIDs, local file IDs, and references between assets.

Generate machine-readable inventory files and a human-readable report.

Create a dependency graph linking each game script to its assets, components, events, and middleware dependencies.

Detect duplicate files, missing references, unresolved GUIDs, unsupported formats, and possible decompilation limitations.

Do not infer that a C# class is unimportant merely because it is small, appears unused, or has a simple name.

## 4. Establish a reproducible Rust project

Create a clean Cargo project with a modular architecture.

Use a stable, compatible set of Rust, Bevy, and supporting crate versions. Inspect the installed toolchain and available crate versions before choosing dependencies. Pin compatible versions in `Cargo.toml` and commit `Cargo.lock`.

Use Bevy-native implementations where they can reproduce the original behavior faithfully.

Potential supporting libraries include:

- Rapier or another suitable Bevy-compatible physics solution.
- Image and texture decoders.
- Animation and skeletal deformation support.
- Audio playback and spatial audio.
- Asset serialization and conversion utilities.
- Compression and binary parsing libraries.
- UI and input utilities when needed.

Verify crate compatibility before adding dependencies. Do not introduce unnecessary dependencies, duplicate systems, or unsupported APIs.

Set up:

- A game library crate and executable.
- Structured logging and configurable diagnostic levels.
- Asset-root configuration.
- Development and release profiles.
- Error reporting for missing or invalid assets.
- Automated formatting and linting.
- Unit and integration tests.
- A deterministic development workflow.
- Automated build and verification scripts.

The game should launch into the correct startup flow once the relevant runtime features and assets are implemented. During development, diagnostic scenes may be used behind a development option, but must not replace the original game's startup flow in the final build.

## 5. Architecture requirements

Use clear module boundaries so the game can be implemented in independent, testable batches.

Recommended architecture:

`src/`
- `main.rs` — executable and application startup.
- `lib.rs` — public module tree.
- `engine/` — time, transforms, scene management, lifecycle, and Unity compatibility utilities.
- `assets/` — asset registries, GUID resolution, conversion, loading, and dependency tracking.
- `game/` — global game state and startup flow.
- `player/` — controller, movement, physics, ragdoll, animation, IK, and abilities.
- `world/` — scene loading, level geometry, environment, and streaming.
- `physics/` — collision queries, rigidbodies, joints, triggers, and collision events.
- `rendering/` — materials, shaders, lighting, post-processing, and special effects.
- `animation/` — skeletal animation, animation graphs, blending, and IK integration.
- `audio/` — sound events, music, spatial playback, buses, snapshots, and parameters.
- `ui/` — menus, HUD, popups, dialogue interfaces, and settings.
- `camera/` — follow cameras, virtual cameras, transitions, collision, and camera effects.
- `save/` — serialization, save slots, progression, and migrations.
- `localization/` — languages, localized strings, and dialogue text.
- `platform/` — achievements, controller support, and platform integrations.
- `middleware/` — compatibility implementations for required middleware APIs.
- `diagnostics/` — profiling, validation, debug displays, and test utilities.

Adapt this structure to the actual source architecture. Do not mechanically create empty directories or modules just to match this list.

Preserve the original C# namespaces and class names where useful for traceability. Every original class should have a recorded disposition, including engine-specific components that require different Rust abstractions.

## 6. Faithful C# porting requirements

For every supplied C# script:

1. Read the entire file.
2. Identify its base class, interfaces, dependencies, serialized fields, and Unity lifecycle methods.
3. Trace calls into related classes and middleware.
4. Port its actual behavior to Rust.
5. Implement required engine behavior instead of replacing it with an empty method.
6. Preserve relevant default values, timing, coordinate conventions, state transitions, event order, and error behavior.
7. Add tests for important pure logic and state transitions.
8. Record the original file, Rust implementation, tests, and outstanding runtime dependencies in the manifest.

### Unity lifecycle

Reproduce the relevant behavior of:

- `Awake`
- `OnEnable`
- `Start`
- `Update`
- `FixedUpdate`
- `LateUpdate`
- `OnDisable`
- `OnDestroy`
- Collision and trigger callbacks
- Scene-load and scene-unload callbacks
- Application focus and pause callbacks

Map these to appropriately ordered Bevy systems, observers, resources, and explicit lifecycle events.

Do not simply call every original method in an arbitrary order once per frame.

### Unity semantics

Reproduce or explicitly adapt:

- Scaled and unscaled time.
- Time scaling and fixed timestep behavior.
- Local and world transforms.
- Quaternion and vector math.
- Unity's coordinate system and handedness conventions.
- Layer masks and collision filtering.
- Trigger versus solid collision semantics.
- Coroutine scheduling and cancellation.
- Delayed invocation and tween timing.
- Object activation and deactivation.
- Parent/child hierarchy behavior.
- Serialization defaults.
- Event subscription and unsubscription.
- Animation timing and update ordering.
- Scene transitions and asynchronous loading.
- Physics interpolation and collision resolution.

Write compatibility wrappers where they prevent subtle behavioral differences from spreading throughout the codebase.

Do not reproduce Unity APIs merely for their names. Reproduce the observable behavior that the original game actually depends on.

## 7. Complete Unity asset pipeline

The original assets are essential to this project. Build a real import and loading pipeline instead of manually recreating the world.

Support every format present in the supplied export that is needed for gameplay.

### Scene and object loading

Implement:

- Unity scene parsing.
- GameObject and component reconstruction.
- Transform hierarchies.
- GUID and local-file-ID resolution.
- Prefab instantiation.
- Scene references.
- Object activation states.
- Component references.
- Trigger volumes.
- Lighting and environment settings.
- Scene transitions.
- Asynchronous loading and unloading.
- Section-based streaming.
- Persistent objects and global scene state.

Preserve parent-child relationships and component execution dependencies.

### Meshes

Support:

- All observed vertex layouts.
- Vertex positions, normals, tangents, UV sets, colors, and indices.
- Multiple vertex streams.
- Submeshes and material assignments.
- Index buffer formats.
- Mesh bounds.
- Skinned meshes.
- Bone indices and weights.
- Bind poses and skeleton references.
- LODs where present.
- Mesh colliders and collision geometry.

Validate imported geometry against the original serialized bounds and metadata.

Do not silently discard skinned meshes or important vertex channels.

### Textures and materials

Implement texture import with appropriate color spaces, filtering, wrapping, mipmaps, compression, and alpha handling.

Resolve material texture references through the actual asset graph rather than relying on manually assembled texture folders.

Preserve:

- Base color and albedo.
- Normal maps.
- Metallic and smoothness parameters.
- Occlusion.
- Emission.
- Transparency and alpha clipping.
- Double-sided rendering.
- Shader keywords and relevant render states.

Build shader replacements that reproduce the original visual behavior. If original shader source is unavailable, inspect all available shader metadata, compiled assets, and material settings before deriving a replacement.

Clearly distinguish verified shader reconstruction from approximation.

### Animation

Import:

- Animation clips.
- Animator controllers.
- State transitions.
- Blend trees.
- Animation parameters.
- Avatar and rig information.
- Root motion.
- Animation events.
- IK constraints.
- Ragdoll transitions.
- Animation-driven object movement.

Ensure that player animation is driven by the actual gameplay state and that animation events trigger the correct game logic.

### Asset validation

Every converted asset must have a recorded import result.

Generate reports showing:

- Successfully imported assets.
- Skipped assets and why they were skipped.
- Missing references.
- Unsupported data.
- Failed conversions.
- Validation results.
- Runtime loading errors.

The pipeline must be repeatable and safe to run again without corrupting already converted assets.

## 8. Reimplement required middleware

Inventory the actual middleware used by the game before choosing replacements.

For each middleware package, identify the original APIs used by the scripts and assets.

Potential systems include:

- FinalIK.
- FMOD.
- Rewired.
- Cinemachine.
- DOTween.
- Zenject.
- Addressables.
- Universal Render Pipeline.
- Timeline.
- TextMeshPro.
- Odin Inspector.
- Steamworks.
- Xbox-specific services.
- Dynamic fog and custom rendering packages.

Implement equivalent behavior through Bevy and compatible Rust libraries where feasible.

Do not create an entire middleware clone when only a subset of its API is required. However, do not omit required APIs simply because they are difficult.

For middleware that has no direct replacement, create an adapter with explicit compatibility tests.

Preserve the distinction between game logic, engine adapters, and platform integrations.

Use only legally available source, documentation, and assets. Do not assume proprietary middleware can be redistributed or copied from the original installation.

## 9. Gameplay implementation

Trace the game's actual startup and level progression flow from the supplied source.

Implement the real systems in dependency order.

### Player

Reproduce the original:

- Movement and input semantics.
- Acceleration and deceleration.
- Grounding and slope behavior.
- Air control.
- Jumping and other movement abilities.
- Grabbing and interactions.
- Ragdoll activation and recovery.
- Physics overrides.
- Collision response.
- Animation and IK.
- Wearables and player visuals.
- Camera-relative movement.
- Death, falling, respawning, and checkpoints.

Use the actual serialized physics presets and tuning parameters when available. Do not substitute arbitrary values without documenting the deviation.

### World and levels

Implement the original:

- Scene hierarchy.
- Level geometry.
- Moving objects.
- Doors and elevators.
- Hazards and force triggers.
- Checkpoints.
- Level events.
- Pickups.
- Dialogue triggers.
- Section loading and unloading.
- World variables.
- Lighting and environment.
- Level transitions.
- Completion and progression conditions.

Preserve trigger ordering and one-shot behavior.

### UI and progression

Implement:

- Title screen.
- Menus and submenus.
- Loading screens.
- Pause and settings.
- Input remapping.
- Sensitivity settings.
- HUD and speedometer.
- Dialogue and subtitles.
- Confirmation popups.
- Save/load interfaces.
- Achievements and leaderboard interfaces where supported.

Do not leave interactive controls as decorative buttons.

### Audio

Map the original audio event definitions to actual playable assets.

Support:

- One-shot events.
- Looping sounds.
- Music transitions.
- Spatial playback.
- Volume and mixer groups.
- Snapshots and global parameters.
- Pause and resume.
- Surface-dependent effects.
- Player and environment sounds.
- Dialogue and sound synchronization.

A queue or statistics resource alone does not count as working audio. Verify that actual sounds can be heard during gameplay.

## 10. Work incrementally with strict quality gates

Do not try to generate the entire project in one enormous batch.

Use the following workflow for each implementation batch:

1. Inspect the relevant C# source and related assets.
2. Identify the exact behavior to reproduce.
3. Trace dependencies and existing Rust implementations.
4. Implement a coherent, working slice.
5. Run formatting.
6. Run `cargo check --all-targets -j 1`.
7. Run relevant unit and integration tests.
8. Run `cargo clippy --all-targets -j 1` and resolve applicable warnings.
9. Launch the game or run a relevant runtime validation when possible.
10. Update the source-to-Rust manifest.
11. Record failures, deviations, and missing inputs.
12. Append a dated progress entry to `RESUME.md`.

Do not claim a test passed unless you ran it and observed the result.

If the build fails, fix the underlying problem before adding unrelated features. Do not silence warnings or errors merely to make the output look clean.

Avoid broad rewrites that destabilize working subsystems.

## 11. Required automated tooling

Create scripts that make the conversion and development process repeatable.

At minimum, provide:

- A project inventory script.
- A source-class coverage report.
- An asset-reference audit.
- An asset conversion command.
- A missing-asset report.
- A build-and-test script.
- A runtime log collection script.
- A progress summary generator.
- A validation report for converted scenes and meshes.

Scripts should report errors clearly, preserve exit codes, and avoid modifying the original project.

Do not use destructive cleanup commands against the source or converted asset directories.

## 12. Persistent documentation

Create and maintain these files in the destination project:

### `README.md`

Include:

- Project purpose.
- Build prerequisites.
- Exact build and run commands.
- Architecture overview.
- Supported asset formats.
- Known limitations.
- Current playable status.
- Source-to-Rust coverage manifest.

### `RESUME.md`

Include:

- Actual project paths.
- Toolchain and dependency versions.
- Last verified build status.
- Last verified test results.
- Current implementation status.
- Completed work.
- Known bugs.
- Missing assets and dependencies.
- Exact next task.
- Relevant file paths.
- A dated append-only changelog.

### `docs/SOURCE_MANIFEST.csv`

Track every original C# class and relevant middleware component.

Required columns:

`source_path,namespace,class_name,rust_path,status,logic_status,engine_binding_status,asset_dependencies,test_status,notes`

Use explicit statuses such as:

- `not_started`
- `investigating`
- `ported_logic`
- `adapter_pending`
- `implemented`
- `verified`
- `blocked`

A class is not `verified` just because a similarly named Rust file exists.

### `docs/ASSET_MANIFEST.csv`

Track original assets, references, conversion results, runtime loading, and validation.

### `docs/KNOWN_DEVIATIONS.md`

Record every known difference from the original game and the evidence behind it.

## 13. Session recovery

At the beginning of every new session:

1. Read `RESUME.md`.
2. Read the project manifest and known deviations.
3. Inspect the current Git diff and repository status.
4. Verify the current toolchain and build state.
5. Inspect the actual files relevant to the next task.
6. Identify the highest-priority incomplete dependency.
7. Continue from the actual state of the project, not from old progress claims.

Before ending a session, update all relevant documentation so another agent can resume without guessing.

Never overwrite the resume file with a short generic summary. Preserve previous changelog entries and append new entries.

## 14. Prioritization

Work in this order, adjusting only when the real dependency graph justifies it:

**Phase A — Foundation**
- Inventory and audit.
- Reproducible Cargo project.
- Asset GUID resolver.
- Core Unity semantics.
- Scene and component model.
- Automated validation.

**Phase B — Real content**
- Load an actual original scene.
- Render converted meshes and materials.
- Resolve real textures.
- Load the correct collision geometry.
- Validate scene transforms and lighting.

**Phase C — Playable gameplay**
- Player controller.
- Physics and collision.
- Camera.
- Animation, IK, and ragdoll.
- Checkpoints, triggers, and level events.
- Real level loading and transitions.

**Phase D — Complete game systems**
- Menus and HUD.
- Audio and music.
- Dialogue and localization.
- Saving and progression.
- Achievements and platform adapters.
- Remaining gameplay scripts.

**Phase E — Visual and behavioral parity**
- Remaining assets.
- Custom shaders.
- Middleware replacements.
- Advanced rendering and effects.
- Performance optimization.
- Full regression testing.

**Phase F — Coverage and release**
- Account for every original script.
- Resolve or explicitly document every required dependency.
- Validate every included scene and asset.
- Complete regression tests.
- Produce a clean Windows build.
- Verify the final game from startup through its playable progression.

Do not stop after Phase B or label an isolated playable slice as the finished game.

## 15. Definition of done

The project is complete only when:

1. Every supplied gameplay script has a faithful implementation or a documented, justified disposition.
2. Required Unity engine behavior has functional Bevy equivalents.
3. All required original assets are converted and loadable.
4. Original scenes, objects, hierarchies, and references resolve correctly.
5. Player movement, physics, animation, IK, and ragdoll work together.
6. Levels, triggers, checkpoints, transitions, and progression function.
7. UI, audio, settings, saving, and other required game systems work.
8. Middleware replacements reproduce the APIs and behavior actually required by the game.
9. Custom rendering features have verified implementations or explicitly documented limitations.
10. The game launches and can be played through the available original progression.
11. Automated tests and builds pass, and runtime failures are resolved.
12. Documentation reflects verified facts rather than optimistic completion percentages.

Never mark the game as a complete 1:1 replica if major systems or assets remain missing.

## 16. Begin now

Start by locating and auditing the actual supplied project and asset folder.

Then:

1. Report the paths found and the contents verified.
2. Generate the initial source and asset manifests.
3. Establish the Rust/Bevy project and run the first build.
4. Identify the smallest real gameplay slice that exercises actual original assets.
5. Implement that slice end to end.
6. Test it, update the manifests, and record the next task.
7. Continue through the dependency graph without abandoning incomplete systems.

Do not respond with only a plan. Perform the available work, modify the destination project, run the applicable checks, and report exactly what was accomplished.

If a critical asset or source file is genuinely unavailable, identify the exact missing file, its expected location, why it is needed, and what independent work can continue without it.

**Final objective: a complete, faithful, playable Rust/Bevy reimplementation of Get to Work using the actual supplied game assets, with every remaining deviation explicitly tracked.**