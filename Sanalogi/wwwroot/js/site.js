const App = new Vue({
    el: '#app',
    data: {
        name: "",
        surname: "",
        phone: "",
        email: "",
        invoiceDate: "",
        invoiceNo: "",
        address: "",
        productName: "",
        productUnitPrice: 0,
        productPiece: 0,
        productValidate: false,
        productsTotalPrice: 0,
        subResponse: "",
        products: [],
        rows: [],
        error: '',
        userError: ''
    },
    methods: {

        //Formu Gönderir
        sub: function () {
            //if (!this.checkUserContent()) {
                var dataToPost = {
                    "name": this.name,
                    "surname": this.surname,
                    "email": this.email,
                    "phone": this.phone,
                    "address": this.address,
                    "invoiceDate": this.invoiceDate,
                    "invoiceNo": this.invoiceNo,
                    "products": this.products
                }

                var sub = this; // axios methodu içinde parent this ' e erişilemediği için burada initialize edildi.
                axios({
                    method: 'post',
                    url: '/api/InvoiceApi',
                    data: dataToPost
                })

                    .then(function (response) {
                        sub.subResponse = response.data;
                        sub.clearProductInputs();
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            //}
        },

        //Ürünleri tabloda yeniden listeler
        listTable: function () {
            this.rows = [];
            var counter = 0;
            this.productsTotalPrice = 0;
            this.products.forEach(item => {
                counter++;
                this.productsTotalPrice += item.UnitPrice * item.Piece;
                this.rows.push({
                    "ID": item.Name + counter,
                    "Name": item.Name,
                    "Piece": item.UnitPrice,
                    "UnitPrice": item.Piece,
                    "TotalPrice": item.UnitPrice * item.Piece
                })
            });
        },

        //Tabloya ve ürünler listemize yeni ürünü ekler.
        addProduct: function () {
            if (this.checkProducts()) {
                this.products.push({ "Name": this.productName, "UnitPrice": this.productUnitPrice, "Piece": this.productPiece });
                this.productName = "";
                this.productUnitPrice = 0;
                this.productPiece = 0;
                this.listTable();
            }

        },

        //Inputlarda düzenleme yapar
        clearProductInputs: function () {
            this.products = [];
            this.productName = "";
            this.productUnitPrice = 0;
            this.productPiece = 0;
            this.listTable();
        },

        //Tablodan ürün siler
        deleteProduct: function (e) {
            this.products.splice(this.products.indexOf(e), 1);
            this.listTable();
        },

        //Ürünler listemizi kontrol eder ve yönlendirir.
        checkProducts: function () {
            if (this.productName == "" || this.productPiece <= 0 || this.productUnitPrice <= 0) {
                this.error = "Ürün bilgisini hatalı veya eksik girdiniz.";
                return false;
            }
            else {
                this.error = "";
                return true;
            }
        },

        //Kullanıcı ve fatura bilgilerini(ürünler hariç) kontrol eder ve yönlendirir.
        checkUserContent: function () {
            if (this.name == "" || this.surname == "" || this.address == "" || this.phone == "" || this.invoiceNo == "" || this.invoiceDate == "") {
                this.userError = "Tüm bilgileri eksiksiz girdiğinizden emin olun.";
                return false;
            } else {
                this.userError = "";
            }
        }

    }
})
