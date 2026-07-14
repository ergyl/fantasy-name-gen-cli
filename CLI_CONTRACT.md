# CLI Contract

Status: draft

This file is a working draft for the first user-facing behavior of the CLI.

## Proposed command shape

- `ff-name <race> [gender] [length] [options]`
- Examples:
```
# Random human name
ff-name human

# Male human short name
ff-name human -m -s

# 20 female elf names
ff-name elf -f -n 20

# 5 dwarf names (reproducible)
ff-name dwarf -n 5 --seed 12345

# See all options
ff-name --help
```

## Args and options
```
Arguments:
  <category>              Name category (human, elf, dwarf, orc)

Options:
  -m, --male              Generate male names
  -f, --female            Generate female names
  -s, --short             Generate short names
  -l, --full              Generate full names (first names + surnames)
  -n, --number <count>    Number of names to generate
      --seed <value>      Seed for reproducible generation
  -h, --help              Show help
```

## Decisions to finalize

- Supported races:
  - [ ] Human
  - [ ] Dwarf
  - [ ] Orc
  - [ ] Elf
  - ... More to come?

- Supported genders:
  - [ ] Male
  - [ ] Female
  - [ ] Random (default)
Gender flags are mutually exclusive: `-m` and `-f` cannot be combined. Non-binary and other options are currently unavailable.

- Supported lengths:
  - [ ] Short (default)
  - [ ] Long

- Input rules:
  - [ ] Case-sensitive
  - [ ] Allow aliases?
  - [ ] Fixed argument order

- Default behavior when no mandatory arg is provided:
  - [ ] Show helpful ("help")

- Seed:
  - [ ] Optional integer.
  - [ ] Same seed + same arguments must produce identical output.
  - [ ] If omitted, use non-deterministic randomness.

- Default behavior for optional args:
  - [ ] Gender: rando
  - [ ] Length: short
  - [ ] Number: 1
  - [ ] Seed: random

- Invalid input behavior:
  - [ ] Show usage and exit non-zero

## Notes

- Keep the parser small and deterministic.
- Keep generation rules separate from CLI parsing.
- **Update this file before implementing tests for Milestone 1.**
