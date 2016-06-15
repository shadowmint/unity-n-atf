# Action Trigger Filter

This is a basic scaffold for actions, triggers and filters.

It doesn't provide any immediately obvious uses, but it's a great
scaffold for building applications.

## Usage

See the tests in the `Editor/` folder for each class for usage examples.

Basic common usage is to use bound services via the `Service` singleton:

```
using N.Package.ATF;
using UnityEngine;

public class MyBehaviour : MonoBehaviour
{
    /// Services
    public IEventService EventService { get; set; }
    public ITriggerService TriggerService { get; set; }

    public void Awake()
    {
        /// Make sure not to just call Registry.Default.Bind() here from
        /// N.Package.Bind; the `Service` class performs smart module lookup!
        Service.Registry.Bind(this);
    }

    public void Start()
    {
        EventService.Action<SomeAction>();

        var action = EventService.Prepare<SomeConfiguredAction>();
        action.Configure(this);
        EventService.Execute(action);
    }
}
```

## Action, Trigger, Filter

- Actions: Perform some async task, eg. start an animation, run a sequence of audio clips.

- Trigger: Trigger various effects, in a specific order using priority.

- Filter: Setup reusable filters using priority order.

ie. These are basic scaffolding for high level 'Command Pattern' types, specifically for complex
duration async events.

## Install

From your unity project folder:

    npm init
    npm install shadowmint/unity-n-atf --save
    echo Assets/packages >> .gitignore
    echo Assets/packages.meta >> .gitignore

The package and all its dependencies will be installed in
your Assets/packages folder.

## Development

Setup and run tests:

    npm install
    npm install ..
    cd test
    npm install
    gulp

Remember that changes made to the test folder are not saved to the package
unless they are copied back into the source folder.

To reinstall the files from the src folder, run `npm install ..` again.

### Tests

All tests are wrapped in `#if ...` blocks to prevent test spam.

You can enable tests in: Player settings > Other Settings > Scripting Define Symbols

The test key for this package is: N_ATF_TESTS
