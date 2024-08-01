module TestHelper
  def assert_equal(actual, expected)
    if expected != actual
      raise "Test failed!\nExpected: #{expected.inspect}\nActual: #{actual.inspect}"
    end
  end

  def run_tests(*tests)
    failures = 0

    tests.each do |test|
      puts "-- Running #{test.name}..."
      begin
        test.call
      rescue StandardError => e
        failures += 1
        puts e, "\n"
      end
    end

    puts "Ran #{tests.length} tests, #{failures} failures."
    if failures.zero?
      puts "All tests passed!"
    end

  end
end
