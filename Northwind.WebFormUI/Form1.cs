using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFremawork;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IProductService _productService = InstanceFactory.GetInstance<IProductService>();
        ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
    
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();  
        }

        private void LoadCategories()
        {
            cmbCategory.DataSource = _categoryService.GetAllList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";

            cmbAddCategory.DataSource = _categoryService.GetAllList();
            cmbAddCategory.DisplayMember = "CategoryName";
            cmbAddCategory.ValueMember = "CategoryId";

            cmbUpdateCategory.DataSource = _categoryService.GetAllList();
            cmbUpdateCategory.DisplayMember = "CategoryName";
            cmbUpdateCategory.ValueMember = "CategoryId";

            
        }

        public void LoadProducts()
        {
           
                dgwProducts.DataSource = _productService.GetAllList();
           
          
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProducts.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cmbCategory.SelectedValue));
            }
            catch 
            
            {

              
            }
           

        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProduct.Text))
            {
                dgwProducts.DataSource = _productService.GetProdustsByProductsName(txtProduct.Text);
            }
            else
            {
                LoadProducts();
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product()
                {
                    ProductName = txtAddName.Text,
                    CategoryId = Convert.ToInt32(cmbAddCategory.SelectedValue),
                    UnitPrice = Convert.ToInt32(txtAddUnirPrice.Text),
                    QuantityPerUnit = txtOuantityPerUnit.Text,
                    UnitsInStock = Convert.ToInt16(txtAddStockAmount.Text)
                });
                MessageBox.Show("Ürün kaydedildi. ");
                LoadProducts();

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
           
        }

        private void cmbAddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtAddStockAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    ProductName = txtUpdateName.Text,
                    CategoryId = Convert.ToInt32(cmbUpdateCategory.SelectedValue),
                    UnitPrice = Convert.ToDecimal(txtUpdateUnitPrice.Text),
                    QuantityPerUnit = txtUpdateQuantityPerUnit.Text,
                    UnitsInStock = Convert.ToInt16(txtUpdateStockAmount.Text)
                });
                MessageBox.Show("Ürün güncellendi. ");
                LoadProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            


        }
            private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProducts.CurrentRow;
            txtUpdateName.Text = row.Cells[2].Value.ToString();
            txtUpdateUnitPrice.Text = row.Cells[3].Value.ToString();
            cmbUpdateCategory.SelectedValue = row.Cells[1].Value;
            txtUpdateQuantityPerUnit.Text = row.Cells[4].Value.ToString();
            txtUpdateStockAmount.Text = row.Cells[5].Value.ToString();
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            {
                ProductId =Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });

            MessageBox.Show("Ürün silindi. ");
            LoadProducts();
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {

           var result = _productService.GetTop10Products();

            dgwProducts.DataSource = result;
        }
    }
}

