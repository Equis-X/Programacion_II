a = ARGS[1]
x = Int
if typeof(tryparse(Int, a)) == x
	a = parse(Int, a)
		for i = 1:a
			println(i)
		end
	println()
else
	println(stderr, a)
end