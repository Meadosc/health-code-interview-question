import Transaction from './transaction.js';
import InvoiceItem from './invoice_item.js';
import TotalSpend from './total_spend.js';
import { assertEqual, runTests } from './test_helper.js';

function testBySpendType1() {
  const txn1 = new Transaction("Insurance premium", "Insurance", 100);
  const itm1 = new InvoiceItem("reimbursement", 100, txn1);

  const txn2 = new Transaction("Dentist appointment", "copay", 11.33);
  const itm2 = new InvoiceItem("overage", 11.33, txn2);

  const total = TotalSpend.bySpendType([itm1, itm2]);

  const expectedTotal = {"reimbursement": 100, "overage": 11.33};
  assertEqual(total, expectedTotal);
}

function testBySpendType2() {
  const txn1 = new Transaction("Insurance premium", "Insurance", 50.75);
  const itm1 = new InvoiceItem("reimbursement", 50.75, txn1);

  const txn2 = new Transaction("Dentist appointment", "copay", 91.25);
  const itm2 = new InvoiceItem("reimbursement", 49.25, txn2);
  const itm3 = new InvoiceItem("overage", 42, txn2);

  const total = TotalSpend.bySpendType([itm1, itm2, itm3]);

  const expectedTotal = {"reimbursement": 100.0, "overage": 42.0};
  assertEqual(total, expectedTotal);
}

function testBySpendTypeAndCategory() {
  const txn1 = new Transaction("Insurance premium", "Insurance", 50.75);
  const itm1 = new InvoiceItem("reimbursement", 50.75, txn1);

  const txn2 = new Transaction("Dentist appointment", "copay", 91.25);
  const itm2 = new InvoiceItem("reimbursement", 49.25, txn2);
  const itm3 = new InvoiceItem("overage", 42, txn2);

  const txn3 = new Transaction("Target purchase", "retail", 5.25);
  const itm4 = new InvoiceItem("overage", 5.25, txn3);

  const txn4 = new Transaction("Amazon purchase", "online", 10.0);
  const itm5 = new InvoiceItem("overage", 10.0, txn4);

  const total = TotalSpend.bySpendTypeAndCategory([itm1, itm2, itm3, itm4, itm5]);

  const expectedTotal = {
    [["reimbursement", "Insurance"]]: 50.75,
    [["reimbursement", "Copay"]]: 49.25,
    [["overage", "Copay"]]: 42.0,
    [["overage", "Other"]]: 15.25
  };
  assertEqual(total, expectedTotal);
}

runTests(
  testBySpendType1,
  testBySpendType2,
  testBySpendTypeAndCategory
);
