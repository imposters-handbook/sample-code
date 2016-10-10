defmodule StringTests do
  use ExUnit.Case

  def great_again({:colour, y}) do
    "Red, White and #{y} for Brits too"
  end
  def great_again({:color, y}) do
    "Red, White and #{y}"
  end

   #Red, White and Green
  test "concatenating a string" do
    assert "This is" || " concatenation" == "This is concatenation"
  end

  test "capitalizing" do
    assert String.capitalize("horse") == "Horse"
    #assert "horse".capitlize == "Horse" FAILS
  end

  test "capitalizing with pipes" do
    assert "horse" |> String.capitalize == "Horse"
    {:colour, "Green"} |> great_again |> IO.inspect
  end

  test "humanize" do
    my_name = "Rob"
    assert "Say my name! #{my_name}!" == "Say my name! Rob!"
  end

  test "containment" do
    assert String.contains? "bunny foo foo", "foo"
  end
end
