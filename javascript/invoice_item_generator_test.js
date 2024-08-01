import Account from './account.js';
import InvoiceItemGenerator from './invoice_item_generator.js';
import Transaction from './transaction.js';
import { assertEqual, runTests } from './test_helper.js';

const testGenerateForTransactions1 = () => {
  const account = new Account("Craig Ellis", 100);
  const txn_1 = new Transaction("Insurance premium", "Insurance", 50);
  const txn_2 = new Transaction("Dentist appointment", "copay", 50);
  const txn_3 = new Transaction("Target purchase", "retail", 5);

  const generated = InvoiceItemGenerator.generateForTransactions(account, [txn_1, txn_2, txn_3]);

  assertEqual(generated[0].spendType, "reimbursement");
  assertEqual(generated[0].amount, 50);
  assertEqual(generated[0].transaction.name, "Insurance premium");

  assertEqual(generated[1].spendType, "reimbursement");
  assertEqual(generated[1].amount, 50);
  assertEqual(generated[1].transaction.name, "Dentist appointment");

  assertEqual(generated[2].spendType, "overage");
  assertEqual(generated[2].amount, 5);
  assertEqual(generated[2].transaction.name, "Target purchase");
};

runTests(
  testGenerateForTransactions1,
);
