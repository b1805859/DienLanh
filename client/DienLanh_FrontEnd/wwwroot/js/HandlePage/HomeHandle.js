
//Get services
async function GetServices() {
    const services = await axios.get(`${Base_URL}/service/`);
    if (services.status == 200) {
        const { data } = services.data

        var serviceHTML = ""

        for (const service of data) {
            serviceHTML += `<div class="col-lg-4 col-md-6 service-item-top wow fadeInUp" data-wow-delay="0.1s">`
            serviceHTML +=`    <div class="overflow-hidden" style="border-radius: 10px 10px 0 0 !important; box-shadow: rgba(0, 0, 0, 0.2) 0px 12px 28px 0px, rgba(0, 0, 0, 0.1) 0px 2px 4px 0px, rgba(255, 255, 255, 0.05) 0px 0px 0px 1px inset;">`
            serviceHTML +=`        <img class="img-fluid w-100 h-100" src="/img/service-1.jpg" alt="">`
            serviceHTML +=`    </div>`
            serviceHTML +=`    <div class="d-flex align-items-center justify-content-between p-4" style="background-color:#ffffff ;border-radius: 0 0 10px 10px !important; box-shadow: rgba(0, 0, 0, 0.2) 0px 12px 28px 0px, rgba(0, 0, 0, 0.1) 0px 2px 4px 0px, rgba(255, 255, 255, 0.05) 0px 0px 0px 1px inset;">`
            serviceHTML +=`        <h6 class="text-truncate me-3 mb-0">${service.title}</h6>`
            serviceHTML +=`        <a class="" href="">Xem chi tiết</a>`
            serviceHTML +=`    </div>`
            serviceHTML +=`</div>`
        }

        $(".services").html(serviceHTML)

    } else {

    }
}


$(function () {
    GetServices()
})