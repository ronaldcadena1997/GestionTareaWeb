"use strict"; var KTJKanbanDemoRich = { init: function () { var s; s = new jKanban({ element: "#kt_docs_jkanban_rich", gutter: "0", click: function (s) { alert(s.innerHTML) }, boards: [{ id: "_backlog", title: "Backlog", class: "light-dark", item: [{ title: `\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                        \t            <img alt="Pic" src="${hostUrl}media/avatars/300-6.jpg" />\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">SEO Optimization</span>\n                        \t            <span class="badge badge-light-success">In progress</span>\n                        \t        </div>\n                        \t    </div>\n                            ` }, { title: '\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                        \t            <span class="symbol-label fs-4">A.D</span>\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Finance</span>\n                        \t            <span class="badge badge-light-danger">Pending</span>\n                        \t        </div>\n                        \t    </div>\n                            ' }] }, { id: "_todo", title: "To Do", class: "light-danger", item: [{ title: `\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                        \t            <img alt="Pic" src="${hostUrl}media/avatars/300-1.jpg" />\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Server Setup</span>\n                        \t            <span class="badge badge-light-info">Completed</span>\n                        \t        </div>\n                        \t    </div>\n                            ` }, { title: `\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                        \t            <img alt="Pic" src="${hostUrl}media/avatars/300-2.jpg" />\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Report Generation</span>\n                        \t            <span class="badge badge-light-warning">Due</span>\n                        \t        </div>\n                        \t    </div>\n                            ` }] }, { id: "_working", title: "Working", class: "light-primary", item: [{ title: `\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                            \t         <img alt="Pic" src="${hostUrl}media/avatars/300-6.jpg" />\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Marketing</span>\n                        \t            <span class="badge badge-light-danger">Planning</span>\n                        \t        </div>\n                        \t    </div>\n                            ` }, { title: '\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-light-info me-3">\n                        \t            <span class="symbol-label fs-4">A.P</span>\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Finance</span>\n                        \t            <span class="badge badge-light-primary">Done</span>\n                        \t        </div>\n                        \t    </div>\n                            ' }] }, { id: "_done", title: "Done", class: "light-success", item: [{ title: `\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                        \t            <img alt="Pic" src="${hostUrl}media/avatars/300-5.jpg" />\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">SEO Optimization</span>\n                        \t            <span class="badge badge-light-success">In progress</span>\n                        \t        </div>\n                        \t    </div>\n                            ` }, { title: `\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-success me-3">\n                        \t            <img alt="Pic" src="${hostUrl}media/avatars/300-20.jpg" />\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Product Team</span>\n                        \t            <span class="badge badge-light-danger">In progress</span>\n                        \t        </div>\n                        \t    </div>\n                            ` }] }, { id: "_deploy", title: "Deploy", class: "light-primary", item: [{ title: '\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-light-warning me-3">\n                        \t            <span class="symbol-label fs-4">D.L</span>\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">SEO Optimization</span>\n                        \t            <span class="badge badge-light-success">In progress</span>\n                        \t        </div>\n                        \t    </div>\n                            ' }, { title: '\n                                <div class="d-flex align-items-center">\n                        \t        <div class="symbol symbol-light-danger me-3">\n                        \t            <span class="symbol-label fs-4">E.K</span>\n                        \t        </div>\n                        \t        <div class="d-flex flex-column align-items-start">\n                        \t            <span class="text-dark-50 fw-bold mb-1">Requirement Study</span>\n                        \t            <span class="badge badge-light-warning">Scheduled</span>\n                        \t        </div>\n                        \t    </div>\n                            ' }] }] }), document.getElementById("addToDo").addEventListener("click", (function () { s.addElement("_todo", { title: `\n                        <div class="d-flex align-items-center">\n                            <div class="symbol symbol-light-primary me-3">\n                                <img alt="Pic" src="${hostUrl}media/avatars/300-23.jpg" />\n                            </div>\n                            <div class="d-flex flex-column align-items-start">\n                                <span class="text-dark-50 fw-bold mb-1">Requirement Study</span>\n                                <span class="badge badge-light-success">Scheduled</span>\n                            </div>\n                        </div>\n                    ` }) })), document.getElementById("addDefault").addEventListener("click", (function () { s.addBoards([{ id: "_default", title: "New Board", class: "light-primary", item: [{ title: `\n                                <div class="d-flex align-items-center">\n                                    <div class="symbol symbol-success me-3">\n                                        <img alt="Pic" src="${hostUrl}media/avatars/300-12.jpg" />\n                                    </div>\n                                    <div class="d-flex flex-column align-items-start">\n                                        <span class="text-dark-50 fw-bold mb-1">Payment Modules</span>\n                                        <span class="badge badge-light-primary">In development</span>\n                                    </div>\n                                </div>\n                        ` }, { title: `\n                                <div class="d-flex align-items-center">\n                                    <div class="symbol symbol-success me-3">\n                                        <img alt="Pic" src="${hostUrl}media/avatars/300-9.jpg" />\n                                    </div>\n                                    <div class="d-flex flex-column align-items-start">\n                                    <span class="text-dark-50 fw-bold mb-1">New Project</span>\n                                    <span class="badge badge-light-danger">Pending</span>\n                                </div>\n                            </div>\n                        ` }] }]) })), document.getElementById("removeBoard").addEventListener("click", (function () { s.removeBoard("_done") })) } }; KTUtil.onDOMContentLoaded((function () { KTJKanbanDemoRich.init() }));