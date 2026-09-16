# Mikado Method — Primitive Obsession (char → Enum)

**Goal:** The player symbol is represented as an Enum rather than a char.

The graph itself is being drawn on paper, so this file has two jobs: keep
a text summary of where the graph currently stands (since paper doesn't
travel between computers or sessions), and log the "Ah-ha!" insights
worth remembering.

## Current graph state (as of 2026-09-16)

Root goal's first naive attempt was changing `SymbolOptions` from a class
of `const char` fields to a real `enum`. That broke 8 sites across
`Game.cs`, `Board.cs`, and `Tile.cs`, grouped into four sibling
prerequisite nodes under the goal:

1. **`Game.cs` comparison logic needs to work with Enum, not char**
   (`IsSymbolNaught`, `IsFirstMove`) — not yet explored.
2. **`Tile` needs to identify the Enum value for space** (`AddSymbol`'s
   taken-check) — not yet explored.
3. **`lastSymbol` in `Game.cs` needs to be Enum** — explored one layer
   deep: recreating the enum + retyping `lastSymbol` revealed a further
   prerequisite, that `Play()` needs to convert the public `char`
   parameter to the enum before assigning it to `lastSymbol`. Resolving
   *that* required a `CharToSymbol` mapper (built as a private method on
   `Game`), which got this branch down to 7 remaining errors (from the
   other three siblings, untouched). But since the whole build still
   wasn't green/committable at that point, the entire branch — enum
   recreation, `lastSymbol`, `Play()` fix, and the mapper — was reverted.
   **Node 3 is not done.** What's known now: its solution shape needs a
   char→Symbol mapper, and that mapper might turn out to be shared with
   nodes 1, 2, and 4 too — worth watching for if it reappears when they're
   explored.
4. **`Board.cs` should handle Enum symbol, not char** (constructor call,
   `HasWinner`'s comparison and return, `ColumnTakenBy`'s ternary) — not
   yet explored.

**Current actual code state:** fully reverted to the clean baseline —
`SymbolOptions` is back to the `const char` class, build succeeds, all 10
tests green. None of the four nodes have been permanently implemented
yet.

**Next step:** pick one of the four nodes (or resume node 3 where it left
off) and continue the naive-attempt → discover → revert cycle.

## Insights

- **Trace the naive attempt back to the true source, not wherever you're
  looking.** Started by considering `Tile`'s constructor as the naive
  attempt, but the char actually originates from `SymbolOptions`. It
  wasn't obvious from the constructor alone that it traced back there —
  even though it was "sort of known," it hadn't been traced explicitly.
  Naive attempts should start at the root definition of the thing you're
  changing, not the first place you happen to be looking at it.

- **Revert doesn't mean "throw the enum away forever."** When exploring a
  child node (like node 3) requires a building block from the original
  broad attempt (the enum itself), it's expected and correct to recreate
  that block as part of the narrower experiment — that's not wasted work.
  The value of reverting isn't avoiding retyping; it's guaranteeing a
  clean, attributable signal for what the *new*, narrower experiment
  specifically causes, and a safe point to fall back to.

- **"Can commit" is the real test for whether work is kept, not "did this
  branch resolve."** Node 3's chain reached a genuine leaf (the
  `CharToSymbol` mapper) — but the overall build still wasn't green,
  because the other three sibling nodes share the same root change (the
  enum) and hadn't been touched. Since none of it could be committed, all
  of it got reverted, including the mapper, even though it "worked."
  Don't confuse "this sub-problem is solved" with "this is safe to keep"
  — only a fully green, tested, committable state counts as kept.

- **Diagnostic ordering from `dotnet build` isn't stable between runs.**
  Diffing two error-list files from back-to-back builds of *identical*
  code showed differences — purely because the compiler emitted the same
  errors in a different order each time, not because anything changed.
  Sort both files before diffing (or build that into tooling) to avoid
  chasing phantom differences.

- **"Green" isn't the same as "clean baseline."** `HEAD` had already
  compiled fine, but it turned out to contain leftover scaffolding
  (`SymbolNew`/`charToSymbol` in `Tile`) from an earlier, abandoned
  standard-refactoring attempt at this same Primitive Obsession problem.
  It didn't break the build, so it looked like a safe starting point —
  but it meant the error list from the naive attempt was a mix of real
  ripple from *this* experiment and fallout from the *old* one, which
  muddied the signal. Before starting a fresh Mikado experiment, check
  that green actually means clean, not just "nothing currently broken."
