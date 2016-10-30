using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankOfBit.Models
{
    /// <summary>
    /// Represents the AccountState table in the database
    /// </summary>
    public class AccountState
    {
        #region Properties

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountStateID { get; set; }

        [Display(Name="Lower\nLimit")]
        [DataType(DataType.Currency)]
        public double LowerLimit { get; set; }

        [Display(Name="Upper\nLimit")]
        [DataType(DataType.Currency)]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name="Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double Rate { get; set; }

        [Display(Name = "Account\nState")]
        public string Description
        {

            get
            {
                if (LowerLimit >= 0 && UpperLimit <= 5000)
                {
                    return (BronzeState.GetInstance().GetType().Name).Replace("State","");
                }
                else if (LowerLimit >= 5001 && UpperLimit <= 10000)
                {
                    return (SilverState.GetInstance().GetType().Name).Replace("State","");
                }
                else if (LowerLimit >= 10001 && UpperLimit <= 20000)
                {
                    return (GoldState.GetInstance().GetType().Name).Replace("State","");
                }
                else
                {
                    return (PlatinumState.GetInstance().GetType().Name).Replace("State","");
                }
            }
        }

        #endregion

        #region Method

        public virtual double RateAdjustment(BankAccount bankAccount)
        {
            return 0;
        }

        public virtual void StateChangeCheck(BankAccount bankAccount){ }

        #endregion
    }

    /// <summary>
    /// Represents AccountState submodel BronzeState
    /// </summary>
    public class BronzeState : AccountState
    {
        //static member
        private static BronzeState bronzeState;

        //constructor
        /// <summary>
        /// 
        /// </summary>
        private BronzeState()
        {
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BronzeState GetInstance() 
        {
            if (bronzeState != null)
                return bronzeState;
            else
            {
                bronzeState = new BronzeState();
                return bronzeState;
            }
        }
       
        public override double RateAdjustment(BankAccount bankAccount)
        {
            return 0;   
        }        

        public void StateChangeCheck(BankAccount bankAccount)
        { }
    }

    /// <summary>
    /// Represents AccountState submodel SilverState
    /// </summary>
    public class SilverState : AccountState
    {
        //static member
        private static SilverState silverState;

        //constructor
        private SilverState()
        { }

        public static SilverState GetInstance() 
        {
            if (silverState != null)
                return silverState;
            else
            {
                silverState = new SilverState();
                return silverState;
            }
            
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            return 0;
        }

        public void StateChangeCheck(BankAccount bankAccount)
        { }
    }

    /// <summary>
    /// Represents AccountState submodel GoldState
    /// </summary>
    public class GoldState : AccountState
    {
        //static member
        private static GoldState goldState;

        //constructor
        private GoldState()
        { }

        public static GoldState GetInstance() 
        {
            if (goldState != null)
                return goldState;
            else
            {
                goldState = new GoldState();
                return goldState;
            }
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            return 0;
        }

        public void StateChangeCheck(BankAccount bankAccount)
        { }
    }

    /// <summary>
    /// Represents AccountState submodel PlatinumState
    /// </summary>
    public class PlatinumState : AccountState
    {
        //static member
        private static PlatinumState platinumState;

        //constructor
        private PlatinumState()
        { }

        public static PlatinumState GetInstance() 
        {
            if (platinumState != null)
                return platinumState;
            else
            {
                platinumState = new PlatinumState();
                return platinumState;
            }
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            return 0;
        }

        public void StateChangeCheck(BankAccount bankAccount)
        { }
    }

    /// <summary>
    /// Represents BankAccount table in the database
    /// </summary>
    public class BankAccount
    {
        #region Properties
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        [Display(Name="Account\nNumber")]
        public int AccountNumber { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        [Required]
        [Display(Name="Current\nBalance")]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        [Required]
        [Display(Name="Opening\nBalance")]
        [DataType(DataType.Currency)]
        public double OpeningBalance { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime DateCreated { get; set; }

        [Display(Name="Account Notes")]
        public string Notes { get; set; }


        public string Description
        {
            get
            {
                return GetType().Name;
            }
        }

        #endregion

        #region Method
        
        public void SetNextAccountNumber()
        {
            
        }

        #endregion

        #region Navigational Properties

        public virtual AccountState AccountState { get; set; }

        public virtual Client Client { get; set; }

        #endregion
    }

    /// <summary>
    ///BankAccount subtype model Saving Account
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        #region Properties

        [Required]
        [Display(Name = "Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double SavingsServiceCharges { get; set; }

        #endregion

        #region Method

        public void SetNextAccountNumber()
        { 
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// BankAccount subtype model Investment Account
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        #region Property

        [Required]
        [Display(Name="Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double InterestRate { get; set; }

        #endregion

        #region Method

        public void SetNextAccountNumber()
        { 
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// BankAccount subtype model Mortgage Account
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        #region Property

        [Required]
        [Display(Name="Interest Rate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double MortgageRate { get; set; }

        [Required]
        public int Amortization { get; set; }

        #endregion

        #region Method

        public void SetNextAccountNumber()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// BankAccount subtype model Chequing Account
    /// </summary>
    public class ChequingAccount : BankAccount
    {
        #region Property

        [Required]
        [Display(Name="Service\nCharges")]
        [DataType(DataType.Currency)]
        public double ChequingServiceCharges { get; set; }

        #endregion

        #region Method

        public void SetNextAccountNumber()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Represents the Client table in the database
    /// </summary>
    public class Client
    {
        #region Properties
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Range(10000000,99999999)]
        [Display(Name="Client")]
        public long ClientNumber { get; set; }

        [Required]
        [Display(Name="First\nName")]
        [StringLength(35,MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last\nName")]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Display(Name="Street\nAddress")]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required(ErrorMessage="Please enter correct Province Code.")]
        [StringLength(2)]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK)$")]
        public string Province { get; set; }

        [Required]
        [StringLength(7)]
        [Display(Name="Postal\nCode")]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name="Date\nCreated")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString ="{0:MM/dd/yyy}")]
        public DateTime DateCreated { get; set; }

        [Display(Name="Client\nNotes")]
        public string Notes { get; set; }

        [Display(Name="Full\nName")]
        public string FullName
        {
            get
            { 
                return FirstName + " " + LastName;
            }
        }

        [Display(Name="Address")]
        public string FullAddress
        {
            get
            {
                return Address + " " + City + " " +
                    Province + " " + PostalCode;
            }
        }

        #endregion

        #region Method

        public void SetNextClientNumber()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Navigational Properties

        public virtual ICollection<BankAccount> BankAccount { get; set; }

        #endregion
    }
}