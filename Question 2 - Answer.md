#### Question 2: A new category was created called PEP (politically exposed person). Also, a new bool property IsPoliticallyExposed was created in the ITrade interface. A trade shall be categorized as PEP if IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this new category.

**Answer:**
First, a new category class called *"PepCategory"* must be created extending the *"BaseCategory"* class and then set the *"CategoryName"* property as *"PEP"*.
Then, create a new category handler called *"PepCategoryHandler"* extending the *"BaseCategoryHandler"* and set the *"Category"* as *"PepCategory"*. In this *"PepCategoryHandler"* you must declare the *"CategoryRule"* method that will return true if the property *"IsPoliticallyExposed"* is true.
Finally, you must add your new handler to the handler list as first at *"TradeCategoryEvaluator"* class to establish the chain of responsability.