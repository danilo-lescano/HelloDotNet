[AssignController("Forms")]
public class t2 : IActionClass{
    public object Resposta(object Thing){
        return (object)((string)Thing + (string)Thing);
    }
}