class Account
  attr_reader :owner, :balance

  def initialize(owner:, starting_balance:)
    @owner = owner
    @balance = starting_balance
  end

  def to_s
    "Account of #{@owner} with starting balance: $#{@balance}"
  end
end
