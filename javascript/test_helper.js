const assertEqual = (actual, expected) => {
  const actualJson = JSON.stringify(actual);
  const expectedJson = JSON.stringify(expected);
  if (actualJson !== expectedJson) {
    throw new Error(`Test failed!\nExpected: ${expectedJson}\nActual: ${actualJson}`);
  }
};

const runTests = (...tests) => {
  let failures = 0;

  tests.forEach(test => {
    console.log(`-- Running ${test.name}...`);
    try {
      test();
    } catch (e) {
      failures++;
      console.log(e, "\n");
    }
  });

  console.log(`Ran ${tests.length} tests, ${failures} failures.`);
  if (failures === 0) {
    console.log("All tests passed!");
  }
};

export { assertEqual, runTests };
