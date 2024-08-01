# Part 1
`mini-code` is, well, a mini version of Thatch. To start, let's fix some broken tests. From the `javascript` directory, run `node total_spend_test.js`. You can assume the tests are written correctly, so if there's a bug, let's try to fix the logic in the code.

# Part 2
Now let's implement the logic that creates the invoice items based on the transactions against a specific account. The balance in the account represents the amount available for reimbursement. Any transaction amounts exceeding the account balance are overages. Head on over to `invoice_item_generator.js`. You can test the logic you implement by running `node invoice_item_generator_test.js`.
