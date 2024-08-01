class TotalSpend {
  static NOTABLE_CATEGORIES = new Set(["Insurance", "Copay"]);

  static bySpendType(invoiceItems) {
    let total = {};
    invoiceItems.forEach((item) => {
      let amount = (total[item.spendType] || 0) + item.transaction.amount;
      total[item.spendType] = amount;
    });
    return total;
  }

  static bySpendTypeAndCategory(invoiceItems) {
    let total = {};
    invoiceItems.forEach((item) => {
      let category;
      if (TotalSpend.NOTABLE_CATEGORIES.has(item.transaction.category)) {
        category = item.transaction.category;
      } else {
        category = "Other";
      }
      let amount = (total[[item.spendType, category]] || 0) + item.amount;
      total[[item.spendType, category]] = amount;
    });
    return total;
  }
}

export default TotalSpend;
