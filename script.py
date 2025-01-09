"""
This script demonstrates basic operations like greeting a user,
checking prime numbers, generating primes up to a limit, and 
calculating factorials.
"""
def greet(name):
    """Greets a user with a message."""
    return f"Hello, {name}!"

def is_prime(num):
    """Checks if a number is prime."""
    if num <= 1:
        return False
    for i in range(2, num):
        if num % i == 0:
            return False
    return True

def prime_numbers_up_to(limit):
    """Generates all prime numbers up to a specified limit."""
    primes = []
    for num in range(2, limit + 1):
        if is_prime(num):
            primes.append(num)
    return primes

def factorial(n):
    """Calculates the factorial of a number."""
    if n in (0, 1):
        return 1
    result = 1
    for i in range(2, n + 1):
        result *= i
    return result

def main():
    """Main function to run various operations."""
    print(greet("Alice"))
    print("\nPrime numbers up to 50:")
    primes = prime_numbers_up_to(50)
    print(primes)
    print("\nFactorial of 5:")
    fact = factorial(5)
    print(fact)
    print("\nPrime numbers up to 100:")
    primes_up_to_100 = prime_numbers_up_to(100)
    print(primes_up_to_100)
    print("\nFactorial of 10:")
    fact_10 = factorial(10)
    print(fact_10)

if __name__ == "__main__":
    main()
