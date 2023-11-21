let app = new Vue({
    el: "#app",
    data: {
        pageTitle: "Vue in Mvc",
        categoriesVisible: false,
        productsVisible: false,
        baseUrl: "https://localhost:44326/api",
        categories: [],
        products: [],
        hasError: false,
        errorMessage: "",
    },
    methods: {
        showCategories: async function () {
            this.hasError = false;
            this.productsVisible = false;
            this.categoriesVisible = true;
            //get the categories from the api
            this.categories = await axios.get(`${this.baseUrl}/categories`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found!";
                    }
                    this.hasError = true;
                });
        },
        showProducts: async function () {
            this.categoriesVisible = false;
            this.productsVisible = true;
            //get the products from the api
            this.products = await axios.get(`${this.baseUrl}/products`)
                .then(response => response.data)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found!";
                    }
                    this.hasError = true;
                })
            console.log(this.products);
        },
    },
});