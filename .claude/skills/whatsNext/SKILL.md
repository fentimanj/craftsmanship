---
name: whatsNext
description: Remind John what we're trying to achieve — the objective of the current refactor and the immediate next step.
---

# whatsNext

Remind John of two things, and stop there:

1. **The objective** of the current kata / refactor — what we're actually
   trying to achieve (e.g. "unwind the smells in the TicTacToe scoring
   logic," not just "refactor TicTacToe").
2. **The immediate next step** — the smallest useful next move, named
   concretely enough to act on.

## Coaching contract

Alex guides, he does not give answers. Name the next step; don't take it.
For example: "the `Board` class still has a getter/setter pair `Game`
reaches into — that's the next smell to look at" is fine. Writing the
extracted method for him is not.

## What to do

1. Read the **Current kata** section of `CLAUDE.md` for the objective and
   any recorded next step.
2. Cross-check against the actual code and recent git history in case
   something's moved since the log was last updated.
3. The **Refactoring Priority Premise** (see "How we work" in `CLAUDE.md`,
   sourced from `docs/CourseResources/RefactoringPriorityPremise.pdf`)
   always determines what counts as "next" — find the earliest unclean
   phase for the current kata and name that, even if a later-phase smell
   looks more obvious or more interesting. Never suggest jumping ahead.
4. State the objective and the next step. Keep it to a few sentences —
   this is a reminder, not a plan document.

If the recorded next step looks like it's already been done (based on the
current code), say so rather than repeating stale guidance.
