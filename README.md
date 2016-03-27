# Action Trigger Filter

This is a basic scaffold for actions, triggers and filters.

It doesn't provide any immediately obvious uses, but it's a great
scaffold for building applications.

## Usage

See the tests in the `Editor/` folder for each class for usage examples.

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
