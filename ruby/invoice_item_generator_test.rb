require './account.rb'
require './invoice_item.rb'
require './invoice_item_generator.rb'
require './test_helper.rb'
require './transaction.rb'

include TestHelper

def test_generate_for_transactions1
  account = Account.new(owner: "Craig Ellis", starting_balance: 100)
  txn_1 = Transaction.new(name: "Insurance premium", category: "Insurance", amount: 50)
  txn_2 = Transaction.new(name: "Dentist appointment", category: "copay", amount: 50)
  txn_3 = Transaction.new(name: "Target purchase", category: "retail", amount: 5)

  generated = InvoiceItemGenerator.generate_for_transactions(account, [txn_1, txn_2, txn_3])

  assert_equal(generated[0].spend_type, "reimbursement")
  assert_equal(generated[0].amount, 50)
  assert_equal(generated[0].transaction.name, "Insurance premium")

  assert_equal(generated[1].spend_type, "reimbursement")
  assert_equal(generated[1].amount, 50)
  assert_equal(generated[1].transaction.name, "Dentist appointment")

  assert_equal(generated[2].spend_type, "overage")
  assert_equal(generated[2].amount, 5)
  assert_equal(generated[2].transaction.name, "Target purchase")
end

run_tests(
  method(:test_generate_for_transactions1),
)
