## Plan: Fantasy Name Generator TDD Backlog

Build the CLI in small TDD slices around three stable boundaries: argument parsing, name generation, and console output. Start by defining the command-line contract for category plus length, then add a deterministic generator core that can be tested without the console, and only after that wire the entrypoint to print results. This keeps each iteration shippable and makes random output testable.

**Milestone 0: Decide the CLI contract** <- completed
1. ~~Define the first supported forms, for example `orc long`, `dwarven short`, and whether order is fixed or flexible.~~
2. ~~Decide the default behavior when no args are provided.~~
3. ~~Decide how invalid inputs are handled: usage text plus non-zero exit code, or fallback defaults.~~
4. ~~Decide whether categories are case-insensitive and whether aliases are allowed.~~

**Milestone 1: Parse and validate args** <- completed
1. ~~Write failing tests for parsing a valid category and length.~~
2. ~~Write failing tests for unknown category, unknown length, and empty input.~~
3. ~~Add tests for normalization, such as `Orc`, `orc`, and `ORC` if you want case-insensitive input.~~
4. ~~Implement the smallest parser that produces a typed request object or validation error.~~

**Milestone 2: Create the generation seam** <- completed
1. ~~Add a request model that captures category, length, and any future knobs.~~
2. ~~Add a generator interface so generation can be tested without `Program.cs`.~~
3. ~~Add a fake or seeded randomness source for deterministic tests.~~
4. ~~Keep the console entrypoint out of the generation logic.~~

**Milestone 3: Implement the first name slice**
1. Pick one category/length combination, such as `orc long`.
2. Write failing tests that assert the output shape, not just a hard-coded random value.
3. Implement a minimal generator that returns one valid name for that slice.
4. Refactor only after the test passes.

**Milestone 4: Expand coverage by table or rule**
1. Add `orc short` as the next test-first increment.
2. Add `dwarven short`, then `dwarven long`.
3. Extract shared word lists or syllable rules as they emerge.
4. Keep each new category or length behind its own red-green-refactor cycle.

**Milestone 5: Polish the CLI surface**
1. Add help/usage output tests.
2. Add tests for exit codes and error messages.
3. Wire `Program.cs` to parse args, call the generator, and print output only.
4. Update the README with real command examples.

**Milestone 6: Presentation polish**
1. Add integration tests for a full CLI invocation path.
2. Add more fantasy categories once the architecture is stable.
3. Add variety rules only after deterministic tests exist.
4. Keep refactoring toward a pure domain core and thin adapters.

**Milestone 7: Final touchups**
1. Add a small ASCII art banner for startup or help output.
2. Add a color theme for prompts, labels, errors, and generated names.
3. Write tests for non-colored fallback behavior where color output is not supported.
4. Make sure presentation code stays separate from generation logic so it can be changed without touching the generator core.

**Relevant files**
- `d:/MY_GIT/DevRepos/fantasy-name-gen-cli/FantasyNameGenerator/Program.cs` — thin CLI orchestration only.
- `d:/MY_GIT/DevRepos/fantasy-name-gen-cli/FantasyNameGenerator/FantasyNameGenerator.csproj` — app project wiring and testability-friendly references if needed.
- `d:/MY_GIT/DevRepos/fantasy-name-gen-cli/README.md` — update command examples, usage notes, and presentation examples.
- `d:/MY_GIT/DevRepos/fantasy-name-gen-cli/FantasyNameGenerator.sln` — add and organize the test project.

**Verification**
1. Run parser tests first, then generation tests, then CLI integration tests.
2. Use deterministic randomness in tests so failures are reproducible.
3. Verify one valid command and one invalid command end-to-end.
4. Add a final console check that confirms ASCII art and color output appear as intended.
5. Keep `dotnet test` green before widening scope.

**Decisions**
- Treat `Program.cs` as a composition root, not a place for generation rules.
- Model category and length as explicit inputs, not ad hoc string concatenation.
- Prefer deterministic tests over snapshotting raw random output.
- Keep presentation formatting optional or safely degradable when the terminal does not support colors.
- Defer large content tables until the core TDD loop is established.

**Further Considerations**
1. Decide whether `orc long` should map to separate word lists or to a format rule over reusable building blocks.
2. Decide whether invalid input should exit with a non-zero code and usage text, or fall back to defaults.
3. Decide whether names should be generated from a fixed catalog, a syllable system, or both for more variety.
