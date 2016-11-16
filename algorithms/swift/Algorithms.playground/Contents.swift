import Foundation

// The various implementations are in the Sources folder (⌘1)

// the list we need to sort
public var list = [23, 4, 42, 15, 16, 8, 3]
// Try commenting this in for performance comparisons
// list = Array(stride(from: 1000, to: 1, by: -1))

bubbleSort(&list)
//mergeSort(&list)
//quickSort(&list)
//selectionSort(&list)

let binaryList = [1,2,3,4,5,6]
binarySearch(list: binaryList, lookFor: 3)

calculateFibAt(20)
fibFaster(20)

sieve(50)
sieveTwo(50)

// Output is printed to the console (click triangle at bottom if necessary)
bellmanFord()
dykstra()
