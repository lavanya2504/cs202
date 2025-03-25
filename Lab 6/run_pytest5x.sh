#!/bin/bash

# Ensure script exits on error
set -e

# Create a directory for logs
LOG_DIR="pytest_logs"
mkdir -p "$LOG_DIR"

# Initialize total time
total_time=0

echo "Running pytest 5 times sequentially..."

for i in {1..5}; do
    echo "Running pytest iteration $i..."
    
    start_time=$(date +%s.%N)  # Capture start time
    pytest | tee "$LOG_DIR/test_run_$i.log"
    end_time=$(date +%s.%N)    # Capture end time
    
    # Calculate elapsed time
    elapsed_time=$(echo "$end_time - $start_time" | bc)
    total_time=$(echo "$total_time + $elapsed_time" | bc)
    
    echo "Test run $i took $elapsed_time seconds"
done

# Calculate and print average execution time
average_time=$(echo "$total_time / 5" | bc -l)
echo "Average execution time (Tseq): $average_time seconds"
echo "$average_time" > "$LOG_DIR/average_time.txt"

echo "All test runs completed. Logs saved in '$LOG_DIR'."
