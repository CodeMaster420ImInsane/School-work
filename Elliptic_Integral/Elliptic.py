import math

def elliptic(n,k):
    k = math.sin(k*math.pi/360)
    s=1
    for i in range(0, n+1):
        p=1
        for j in range(1,2*i+2,2):
            p *= j/(j+1)
        s+= (p)**2 * k**(2*(i+1))
    return float(math.pi*s/2)

l = float(input("String length: \n"))
g = float(input("Gravitational acceleration: \n"))
phi = float(input("Initial displacement: \n"))
n = int(input("Degree of approximation: \n"))

print("Period time T = ", 4* math.sqrt(l/g) * elliptic(n, phi))
