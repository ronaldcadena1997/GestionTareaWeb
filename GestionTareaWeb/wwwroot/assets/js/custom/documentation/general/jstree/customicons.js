"use strict"; var KTJSTreeCustomIcons = { init: function () { $("#kt_docs_jstree_customicons").jstree({ core: { themes: { responsive: !1 } }, types: { default: { icon: "fa fa-folder text-warning" }, file: { icon: "fa fa-file  text-warning" } }, plugins: ["types"] }), $("#kt_docs_jstree_customicons").on("select_node.jstree", (function (t, e) { var n = $("#" + e.selected).find("a"); if ("#" != n.attr("href") && "javascript:;" != n.attr("href") && "" != n.attr("href")) return "_blank" == n.attr("target") && (n.attr("href").target = "_blank"), document.location.href = n.attr("href"), !1 })) } }; KTUtil.onDOMContentLoaded((function () { KTJSTreeCustomIcons.init() }));