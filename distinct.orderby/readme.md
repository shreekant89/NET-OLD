if you have 1000 recored then:---------------------------------
Distinct().OrderBy():-
Execution time (ticks): 6294
OrderBy().Distinct():-
Execution time (ticks): 8211

if you have 28 recored then:---------------------------
Distinct().OrderBy():-
Execution time (ticks): 7680
OrderBy().Distinct():-
Execution time (ticks): 7525


so if its less(28) record then  OrderBy().Distinct(): is giving better result but if its 1000 record then 
Distinct().OrderBy():- is mostly give better result 