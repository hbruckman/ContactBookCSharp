using System;
using Xunit;
using ContactBook;

namespace ContactBook.Tests
{
	public class ContactTests
	{
		#region Constructor & Getters

		[Fact]
		public void Constructor_DefaultValues_ShouldInitializeWithEmptyStrings()
		{
			// Act
			var contact = new Contact();

			// Assert
			Assert.Equal(string.Empty, contact.GetFName());
			Assert.Equal(string.Empty, contact.GetLName());
			Assert.Equal(string.Empty, contact.GetPhone());
			Assert.Equal(string.Empty, contact.GetEmail());
		}

		[Fact]
		public void Constructor_WithValues_ShouldAssignProperties()
		{
			// Arrange
			const string fname = "John";
			const string lname = "Doe";
			const string phone = "123-456-7890";
			const string email = "john.doe@example.com";

			// Act
			var contact = new Contact(fname, lname, phone, email);

			// Assert
			Assert.Equal(fname, contact.GetFName());
			Assert.Equal(lname, contact.GetLName());
			Assert.Equal(phone, contact.GetPhone());
			Assert.Equal(email, contact.GetEmail());
		}

		#endregion

		#region Setters

		[Fact]
		public void SetFName_ShouldUpdateFirstName()
		{
			// Arrange
			var contact = new Contact();
			const string newFName = "Alice";

			// Act
			contact.SetFName(newFName);

			// Assert
			Assert.Equal(newFName, contact.GetFName());
		}

		[Fact]
		public void SetLName_ShouldUpdateLastName()
		{
			// Arrange
			var contact = new Contact();
			const string newLName = "Smith";

			// Act
			contact.SetLName(newLName);

			// Assert
			Assert.Equal(newLName, contact.GetLName());
		}

		[Fact]
		public void SetPhone_ShouldUpdatePhone()
		{
			// Arrange
			var contact = new Contact();
			const string newPhone = "987-654-3210";

			// Act
			contact.SetPhone(newPhone);

			// Assert
			Assert.Equal(newPhone, contact.GetPhone());
		}

		[Fact]
		public void SetEmail_ShouldUpdateEmail()
		{
			// Arrange
			var contact = new Contact();
			const string newEmail = "alice.smith@example.com";

			// Act
			contact.SetEmail(newEmail);

			// Assert
			Assert.Equal(newEmail, contact.GetEmail());
		}

		#endregion

		#region ToString

		[Fact]
		public void ToString_ShouldReturnFormattedStringWithValues()
		{
			// Arrange
			var contact = new Contact(
				fname: "John",
				lname: "Doe",
				phone: "123-456-7890",
				email: "john.doe@example.com"
			);

			// Act
			var result = contact.ToString();

			// Assert
			Assert.Equal(
				"Contact[fname=John, lname=Doe, phone=123-456-7890, email=john.doe@example.com]",
				result
			);
		}

		[Fact]
		public void ToString_WithDefaultConstructor_ShouldShowEmptyValues()
		{
			// Arrange
			var contact = new Contact();

			// Act
			var result = contact.ToString();

			// Assert
			Assert.Equal(
				"Contact[fname=, lname=, phone=, email=]",
				result
			);
		}

		#endregion

		#region Equals(Contact) and Equals(object)

		[Fact]
		public void EqualsContact_SameReference_ShouldReturnTrue()
		{
			// Arrange
			var contact = new Contact("John", "Doe", "123", "john@example.com");
			var sameReference = contact;

			// Act
			var result = contact.Equals(sameReference);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void EqualsContact_Null_ShouldReturnFalse()
		{
			// Arrange
			var contact = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			var result = contact.Equals((Contact?)null);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualsContact_IdenticalValues_ShouldReturnTrue()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			var result = c1.Equals(c2);

			// Assert
			Assert.True(result);
			Assert.True(c2.Equals(c1)); // symmetry
		}

		[Fact]
		public void EqualsContact_DifferentFirstName_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("Jane", "Doe", "123", "john@example.com");

			// Act
			var result = c1.Equals(c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualsContact_DifferentLastName_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Smith", "123", "john@example.com");

			// Act
			var result = c1.Equals(c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualsContact_DifferentPhone_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "456", "john@example.com");

			// Act
			var result = c1.Equals(c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualsContact_DifferentEmail_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "123", "johnny@example.com");

			// Act
			var result = c1.Equals(c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualsObject_WithContact_ShouldBehaveLikeEqualsContact()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			object c2 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			var result = c1.Equals(c2);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void EqualsObject_WithNull_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			var result = c1.Equals((object?)null);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualsObject_WithDifferentType_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			object notAContact = "Not a contact";

			// Act
			var result = c1.Equals(notAContact);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void Equals_IsTransitive()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "123", "john@example.com");
			var c3 = new Contact("John", "Doe", "123", "john@example.com");

			// Act & Assert
			Assert.True(c1.Equals(c2));
			Assert.True(c2.Equals(c3));
			Assert.True(c1.Equals(c3)); // transitivity
		}

		#endregion

		#region Equality Operators == and !=

		[Fact]
		public void EqualityOperator_BothNull_ShouldReturnTrue()
		{
			// Arrange
			Contact? c1 = null;
			Contact? c2 = null;

			// Act
			bool result = (c1 == c2);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void EqualityOperator_LeftNullRightNotNull_ShouldReturnFalse()
		{
			// Arrange
			Contact? c1 = null;
			Contact? c2 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			bool result = (c1 == c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualityOperator_LeftNotNullRightNull_ShouldReturnFalse()
		{
			// Arrange
			Contact? c1 = new Contact("John", "Doe", "123", "john@example.com");
			Contact? c2 = null;

			// Act
			bool result = (c1 == c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void EqualityOperator_IdenticalValues_ShouldReturnTrue()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			bool result = (c1 == c2);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void InequalityOperator_IdenticalValues_ShouldReturnFalse()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			bool result = (c1 != c2);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void InequalityOperator_DifferentValues_ShouldReturnTrue()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("Jane", "Doe", "123", "john@example.com");

			// Act
			bool result = (c1 != c2);

			// Assert
			Assert.True(result);
		}

		#endregion

		#region GetHashCode

		[Fact]
		public void GetHashCode_EqualObjects_ShouldHaveSameHashCode()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			int hash1 = c1.GetHashCode();
			int hash2 = c2.GetHashCode();

			// Assert
			Assert.Equal(hash1, hash2);
		}

		[Fact]
		public void GetHashCode_DifferentObjects_ShouldHaveDifferentHashCodes_MostOfTheTime()
		{
			// Note: Different objects are not *required* to have different hash codes,
			// but it is generally expected for well-distributed hash implementations.
			// We'll still assert inequality here to catch regressions in Combine usage.

			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");
			var c2 = new Contact("Jane", "Doe", "123", "john@example.com");

			// Act
			int hash1 = c1.GetHashCode();
			int hash2 = c2.GetHashCode();

			// Assert
			Assert.NotEqual(hash1, hash2);
		}

		[Fact]
		public void GetHashCode_SameInstanceMultipleCalls_ShouldBeStable()
		{
			// Arrange
			var c1 = new Contact("John", "Doe", "123", "john@example.com");

			// Act
			int hash1 = c1.GetHashCode();
			int hash2 = c1.GetHashCode();
			int hash3 = c1.GetHashCode();

			// Assert
			Assert.Equal(hash1, hash2);
			Assert.Equal(hash1, hash3);
		}

		#endregion
	}
}
