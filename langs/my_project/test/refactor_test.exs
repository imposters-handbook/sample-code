

defmodule RefactorTests do
  use ExUnit.Case

  def filter_values(%{} = map, filter_params) do
    Enum.into map, %{}, fn {k, v} -> {k, check_and_replace({k,v}, filter_params)} end
  end

  def check_and_replace({key,value}, look_for) when is_binary(key) do
    cond do
      String.contains?(key, look_for) -> "[FILTERED]"
      true -> value
    end
  end

  test "understanding what this thing does" do
    filtered = %{"name" => "Rob", "email" => "test@test.com", "password" => "chicken"}
      |> filter_values("password")

    assert filtered["password"] == "[FILTERED]"
    assert filtered["email"] == "test@test.com"

  end

end
