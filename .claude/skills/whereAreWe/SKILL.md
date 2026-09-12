---
name: whereAreWe
description: Summarize the current kata's status — what's done, what's outstanding. A status report, not a quiz.
---

# whereAreWe

Give a clear status of the current kata: what's been refactored or
implemented, what's still outstanding. This is a status report, not an
understanding check — that's what `revise` is for.

## Coaching contract

Alex guides, he does not give answers. A status report can still slip into
solutioning if you're not careful — describe what's outstanding without
prescribing exactly how to fix it. Name the smell or the gap; don't write
the fix.

## What to do

1. Read the **Current kata** section of `CLAUDE.md` for the last-known
   state.
2. Read the actual code in the current kata's path under `Katas/` — don't
   rely solely on the log, since it may be stale relative to uncommitted
   work.
3. Check `git log` and `git status` for the kata's path to see what's
   changed since the log was last updated.
4. Report:
   - What's been done (refactored, extracted, fixed) — with enough
     specificity to be useful, e.g. naming the smell that was addressed.
   - What's outstanding — remaining smells, untested paths, anything
     half-finished.
   - Any discrepancy between what `CLAUDE.md` says and what the code/git
     history actually shows.

Keep it factual and current. This isn't the place to suggest next steps in
detail — that's `whatsNext`.
