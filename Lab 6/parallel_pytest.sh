#!/bin/bash

# Define output file
LOG_FILE="parallel_test_results.log"
echo "Parallel Test Execution Results" > $LOG_FILE

# Configurations for parallel execution
WORKERS=("1" "auto")  # Number of processes
THREADS=("1" "auto")  # Number of threads
DISTRIBUTION_MODES=("load" "no")  # Pytest-xdist modes

# Run tests in all configurations
for w in "${WORKERS[@]}"; do
    for t in "${THREADS[@]}"; do
        for dist in "${DISTRIBUTION_MODES[@]}"; do
            echo "Running tests with -n $w --parallel-threads $t --dist $dist" | tee -a $LOG_FILE
            total_time=0

            # Execute 3 repetitions
            for i in {1..3}; do
                echo "Iteration $i..." | tee -a $LOG_FILE
                START_TIME=$(date +%s.%N)
                pytest -n "$w" --parallel-threads "$t" --dist "$dist" --tb=short | tee -a "test_output_$w_$t_$dist.log"
                END_TIME=$(date +%s.%N)

                # Calculate execution time
                EXEC_TIME=$(echo "$END_TIME - $START_TIME" | bc)
                total_time=$(echo "$total_time + $EXEC_TIME" | bc)
                echo "Execution Time: $EXEC_TIME seconds" | tee -a $LOG_FILE

                # Record failing test cases
                grep -E "FAILED|ERROR" "test_output_$w_$t_$dist.log" | tee -a "$LOG_FILE"
            done

            # Compute average execution time
            avg_time=$(echo "$total_time / 3" | bc -l)
            echo "Average Execution Time (Tpar): $avg_time seconds" | tee -a $LOG_FILE
            echo "-------------------------------------" | tee -a $LOG_FILE
        done
    done
done

echo "Parallel testing completed! Results are stored in $LOG_FILE"
