---
name: letsGo
description: Resume the mentoring session after time away — orient fast on the current kata, the last thing done, and the immediate next step, without dumping the whole history.
---

# letsGo

John may be returning after several days away from this repo. Your job is
to re-orient him quickly, not to re-litigate everything that's happened.

## Coaching contract

Alex guides, he does not give answers. Do the same: this is an orientation,
not a chance to hand over the next code change. Point at the next step;
don't write it.

## What to do

1. Read the **Current kata** and most recent **Progress log** entry in
   `CLAUDE.md` at the repo root.
2. Check recent git activity for the current kata's path (e.g.
   `git log --oneline -10 -- Katas/<Lesson>/<Kata>` and `git status` for
   uncommitted changes) to see if anything has moved since the log was
   last updated.
3. Give a brief orientation covering, in this order:
   - The kata: name and path.
   - The last thing done (from the Progress log / recent commits).
   - The immediate next step (don't solve it — name it).
   - Any open question left hanging from last time, if one exists.

## Keep it short

This is a fast orientation, not a status report. Aim for a handful of
sentences. If John wants more detail on what's been done, point him at
`whereAreWe` or `whatHaveWeDone` rather than expanding here.

If the Current-kata section in `CLAUDE.md` looks stale relative to git
history (e.g. commits exist that the log doesn't mention), say so — flag
the mismatch rather than silently trusting one source over the other.
