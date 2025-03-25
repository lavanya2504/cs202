#!/bin/bash

# Create a directory to store outputs
mkdir -p pytest_outputs

for i in {1..10}
do
    echo "Running pytest iteration $i..."
    pytest > "pytest_outputs/run_$i.txt" 2>&1
done

echo "Pytest has been executed 10 times. Check the 'pytest_outputs' folder for results."
