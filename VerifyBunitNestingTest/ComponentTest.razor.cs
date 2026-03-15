using Bunit;

namespace VerifyBunitNestingTest;

public partial class ComponentTest : BunitContext
{
    [Fact]
    public async Task Test1()
    {
        // Act.
        var cut = Render(_fragment);

        // Assert.
        await Verify(cut);
    }
}
