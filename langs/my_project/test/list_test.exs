defmodule ListTests do
  use ExUnit.Case

  test "a simple for loop" do
    for x <- 1..10, do: IO.inspect x
  end

  test "a filtered for loop" do
    for x <- 1..10, x > 5, do: IO.inspect x * x
  end

  test "a filtered for loop with multiple generators" do
    for x <- 1..10, y <-[2,3], x > 5, do: IO.inspect x * y
  end

end
