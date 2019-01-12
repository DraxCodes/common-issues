<p align="center">
    <img src="../../Images/CustomPreconditions.png">
</p>

# Custom Preconditions Example

**__NOTE__: This is an example, while this precondition works (It requires a command be ran in a specific guild), It is meant as a guide only.**

**This example will allow you to better understand the creation of custom Preconditions.**

## How To Add To Your Project

Go to the Class [Here](CustomPrecondition.cs) then copy all the raw data of the .cs file into your own new class in your bot project. Or Download the file and add the .cs to your project.

Change the Namespace to reflect your project. In our case we have a bot named MyAwesomeBot and the pronditions are in a folder named Preconditions.

```cs
namespace MyAwesomeBot.Preconditions
```

## Understanding The Example

You can find this line in the .cs file on line 9. This is where you will setup any variables you intend on using for your precondition. Seeing as we're creating a precondition that makes the command require a specific guild to be ran. We will need the GuildID to check against.

```cs
//your variables
private ulong _guildId;  
```

Here is where we setup how the precondition is going to be used. In this example the intended use is ``[RequireSpecificGuild(GuildIdHere)]`` As such we will name the class to reflect this. Our class is named:

```cs
public class RequireSpecificGuild : PreconditionAttribute
```

* Note how we have ``: PreconditionAttribute``
  * This is because we're inheriting from the ``PreconditionAttribute`` class.
  
Now we need to create a constructor for the attribute, here is where we will define any parameters we require for the precondition.

* **Note**: Remember that a constructer is called whenever this class is instantiated.

```cs
public RequireSpecificGuild(ulong guildId)
        {
            //Apply the value we recieve from the precondition being called
            //To the Variable/Property we have set above in the Variables section.
           _guildId = guildId;
        }
```

Now We can set out our logic for the precondition. To this we have to overried the default way the ``CheckPermissionsAsync`` method functions (To add our precondition to it).

```cs
public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
{
    if(context.Guild.Id != _guildId)
    {
        //Your command handler will get an error with this message
        return Task.FromResult(PreconditionResult.FromError($"You can't use this command in this guild."));
        }
        else
        {
            //Command wil execute
            return Task.FromResult(PreconditionResult.FromSuccess());
        }
}
```

In the above Example it's doing a very simple check using ``if``. Essentially it checks if the GuildID we gave our precondition when we set it on a Module (See Below) is the same as the the GuildID of the guild which the command has been used in. If it's the same GuildID then the command is allowed to continue, if it is a different GuildID the command will not run and instead will return the error we have defined by:

```cs
return Task.FromResult(PreconditionResult.FromError($"You can't use this command in this guild."));
```

### Add The Precondition to a command

This is the easiest part of the whole process. Now you have the Precondition setup you will first need to add a Using Directive for the Precondition 

* **NOTE:** This depends on how you set your bot up, if you don't have your precondition in a different folder to the rest of your bot then this step may not be required

```cs
using MyAwesomeBot.Preconditions
```

Now we can add the precondition to our command.

```cs
[Command("Ping")][RequireSpecificGuild(GuildIdHere)]
public async Task Ping(){
    await ReplyAsync("Pong");
}
```

---

That's it. If you have any issues using this or just need some help adding to it use the links below to find us on Discord.

Code Author: Charly#7094

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)