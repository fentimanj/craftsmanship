# Mikado Method — Primitive Obsession (char → Enum)

**Goal:** The player symbol is represented as an Enum rather than a char.

Running log of "Ah-ha!" moments as the graph gets built — not a step-by-step
history of the graph itself (that's on paper), just the insights worth
keeping.

## Insights

- **Trace the naive attempt back to the true source, not wherever you're
  looking.** Started by considering `Tile`'s constructor as the naive
  attempt, but the char actually originates from `SymbolOptions`. It
  wasn't obvious from the constructor alone that it traced back there —
  even though it was "sort of known," it hadn't been traced explicitly.
  Naive attempts should start at the root definition of the thing you're
  changing, not the first place you happen to be looking at it.

- **"Green" isn't the same as "clean baseline."** `HEAD` had already
  compiled fine, but it turned out to contain leftover scaffolding
  (`SymbolNew`/`charToSymbol` in `Tile`) from an earlier, abandoned
  standard-refactoring attempt at this same Primitive Obsession problem.
  It didn't break the build, so it looked like a safe starting point —
  but it meant the error list from the naive attempt was a mix of real
  ripple from *this* experiment and fallout from the *old* one, which
  muddied the signal. Before starting a fresh Mikado experiment, check
  that green actually means clean, not just "nothing currently broken."
