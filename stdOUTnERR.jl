#>>txt.txt
c = readline()
a = readlines(c)
b = length(a)

for i=1:b
  if (length(a[i])>6)
    println(stderr, a[i])
  else
    println(stdout, a[i])
  end
end
