using MyBudget.Pages;
using Xunit;

namespace MyBudget.Tests
{
	public class UnitTest1
	{
		private IndexModel model;

		public UnitTest1()
		{
			model = new IndexModel();
		}

		[Fact]
		public void AddMoneyTest()
		{
			model.Total = 0;
			model.OnPostAddAsync();
			Assert.Equal(1, model.Total);			
		}

		[Fact]
		public void RemoveMoneyTest()
		{
			model.Total = 1;
			model.OnPostRemoveAsync();
			Assert.Equal(0, model.Total);
		}

		[Fact]
		public void RemoveMoneyWhenLessThanZeroTest()
		{
			model.Total = 0;
			model.OnPostRemoveAsync();
			Assert.Equal(0, model.Total);
		}

	}
}
