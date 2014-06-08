Imports Entities.User

Public Interface IAccesibleMultiThread
    Property NeedExecute As Boolean
    Sub AddComponent(ByVal request As Request)
    Sub ExecuteMethod(method As [Delegate], ParamArray args As Object())
End Interface
