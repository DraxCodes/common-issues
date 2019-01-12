<p align="center">
    <img src="../Images/Issues.png">
</p>

# BadArgCount: The input text has too few parameters

**This error is caused when you have a command that requires one or more parameters, however you give it less than it requires.**

## Understanding What's Going On

- The primary cause of this is not understanding how paramerters work in command tasks.
  - Below is an example of a very simple command.

```cs
[Command("Say")]
public async Task Say(string text)
{
    await ReplyAsync($"You said: {text}");
}
```

This command is simply going to repeate whatever we say after we use the `!say` command.

- Incrrect Example:
  - !say
  - Bot: BadArgCount: The input text has too few parameters.

- Correct Example:
  - !say Hello
  - Bot: You said: Hello

As you can see from the above example, when we use `!say` on it's own, it results in the error. This is because in our command, we defined a parameter;

```cs
string text
```

So when we just try to use `!say` as the command, the Task doesn't know what to do as it requires the extra input. Doing `!say Hello`, the `Hello` part of the command fulfils what the Task needs and runs normally.

- **NOTE: This example command is not meant to be used, For a more detailed guide on Commands check out our Basic Command Guide [Here](../Discord.Net-Addons/BasicCommands)**
