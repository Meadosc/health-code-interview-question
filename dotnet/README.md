# Part 1
`MiniCode` is, well, a mini version of Thatch. To start, let's fix some broken tests. From the `dotnet` directory, run `dotnet run --project MiniCodeTest`. This runs two test suites. You can assume the tests are written correctly, so if there's a bug, let's try to fix the logic in the code. Let's start with the `TotalSpendTest`.

# Part 2
You'll notice there's still one test failing. To fix it, let's implement the logic that creates the invoice items based on the transactions against a specific account. The balance in the account represents the amount available for reimbursement. Any transaction amounts exceeding the account balance are overages. Head on over to `InvoiceItemGenerator.cs`. You can test the logic you implement by running `dotnet run --project MiniCodeTest`.
