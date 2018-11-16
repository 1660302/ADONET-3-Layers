using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_3_Layers_GiaoDien
{
    class Product
    {
        int mId;
        String mName;
        int mSupplierId;
        int mCategoryId;
        String mQuantityPerUnit;
        double mUnitPrice;
        int mUnitsInStock;
        int mUnitsOnOrder;
        int mReorderLevel;
        int mDiscontinued;

        public int Id
        {
            get
            {
                return mId;
            }

            set
            {
                mId = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public int SupplierId
        {
            get
            {
                return mSupplierId;
            }

            set
            {
                mSupplierId = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return mCategoryId;
            }

            set
            {
                mCategoryId = value;
            }
        }

        public string QuantityPerUnit
        {
            get
            {
                return mQuantityPerUnit;
            }

            set
            {
                mQuantityPerUnit = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return mUnitPrice;
            }

            set
            {
                mUnitPrice = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return mUnitsInStock;
            }

            set
            {
                mUnitsInStock = value;
            }
        }

        public int UnitsOnOrder
        {
            get
            {
                return mUnitsOnOrder;
            }

            set
            {
                mUnitsOnOrder = value;
            }
        }

        public int ReorderLevel
        {
            get
            {
                return mReorderLevel;
            }

            set
            {
                mReorderLevel = value;
            }
        }

        public int Discontinued
        {
            get
            {
                return mDiscontinued;
            }

            set
            {
                mDiscontinued = value;
            }
        }

        public Product()
        {

        }

        

    }
}
