let app = new Vue({
    el: "#app",
    data: {
        pageTitle: "Vue in Mvc",
        categoriesVisible: false,
        productsVisible: false,
        baseUrl: "https://localhost:44326/api",
        categories: [],
        loading: false,
        products: [],
        hasError: false,
        errorMessage: "",
    },
    methods: {
        showCategories: async function () {
            this.hasError = false;
            this.productsVisible = false;
            this.loading = true;
            //get the categories from the api
            this.categories = await axios.get(`${this.baseUrl}/categories`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found!";
                    }
                    this.hasError = true;
                });
            this.categoriesVisible = true;
            this.loading = false;
        },
        showProducts: async function (categoryId = null) {
            let url = `${this.baseUrl}/products`;
            if (categoryId !== null) {
                url += `/category/${categoryId}`;
            }
            
            this.hasError = false;
            this.categoriesVisible = false;
            this.loading = true;
            //get the products from the api
            this.products = await axios.get(url)
                .then(response => response.data)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found!";
                    }
                    this.hasError = true;
                })
                .finally(() => {
                    this.productsVisible = true;
                    this.loading = false;
                });
        },
    },
});