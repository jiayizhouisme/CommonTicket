layui.define(['layer','laydate'],function(exports){
    var layer = layui.layer // 获得 layer 模块
    var laydate = layui.laydate; // 获得 laydate 模块

    layer.msg("hello layui", { icon: 6 });
    // 输出模块
        exports('demo', {
            msg: '12332131234567'
        }); // 模块名 demo 未被占用，此时模块定义成功
});