function getSelected(event) {    
    var selectedValues=0;
    $checkedCheckboxes = $("input:checkbox[name=" + event.data.name + "]:checked");
    $checkedCheckboxes.each(function () {
        selectedValues += parseInt($(this).val());
    });
    $("#" + event.data.name).val(selectedValues);
}

$("input[name=meyveler]").on("click", { name: "meyveler" }, getSelected);  // parameter given
$("input[name=sebzeler]").on("click", { name: "sebzeler" }, getSelected);
$("input[name=baklagiller]").on("click", { name: "baklagiller" }, getSelected);
$("input[name=etler]").on("click", { name: "etler" }, getSelected);
$("input[name=süt-ve-yumurta-ürünleri]").on("click", { name: "süt-ve-yumurta-ürünleri" }, getSelected);
$("input[name=deniz-ürünleri]").on("click", { name: "deniz-ürünleri" }, getSelected);
$("input[name=kuruyemişler]").on("click", { name: "kuruyemişler" }, getSelected);
$("input[name=yağlar]").on("click", { name: "yağlar" }, getSelected);