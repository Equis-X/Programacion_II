r = [0]

while true
	a = readline()
	if typeof(tryparse(Int, a))==Int64
		if r[1] == 0
			pop!(r)
		end
		push!(r, parse(Int, a))
	end
	typeof(tryparse(Int, a))!=Int64 && break
end

k = sum!([1], r)

println(k[1])
println()