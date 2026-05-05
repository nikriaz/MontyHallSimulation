# 🎲 Monty Hall Simulator (C#)

You pick 1 of 3 doors. The host (who knows where the prize is) opens another door with a goat and offers you to switch. It *feels* like 50/50 — this simulation shows it isn’t.

Run it and you’ll consistently get ~33% wins if you **stay** and ~66% if you **switch**. The difference comes from the host’s action: he doesn’t open a random door, he **intentionally removes a losing option**, which shifts the odds.

```bash
dotnet run          # ~5 seconds auto-run
dotnet run -- 1000000
```

Switching wins. Every time (statistically).
