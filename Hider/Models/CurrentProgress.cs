

namespace Hider.Models;

public class  CurrentProgress :ValueChangedMessage<int>
{
	public CurrentProgress(int value): base(value)
	{

	}
}
