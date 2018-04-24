<template>
  <div class="wd1200">
     <ul class="linklist">
        <li><a a href="https://www.ele.me" target="_blank">淘宝网</a></li>
        <li><a a href="https://www.ele.me" target="_blank">天猫</a></li>
        <li><a a href="https://www.ele.me" target="_blank">聚划算</a></li>
        <li><a a href="https://www.ele.me" target="_blank">全球速实通</a></li>
        <li><a a href="https://www.ele.me" target="_blank">阿里巴巴国际交易市场</a></li>
        <li><a a href="https://www.ele.me" target="_blank">1688</a></li>
        <li><a a href="https://www.ele.me" target="_blank">阿里妈妈</a></li>
     </ul>
     <p class="copyright">©copyright 2016-2018 优样品 www.youyangpin.com.<a href="http://www.beianbeian.com/beianxinxi/a40cc71f-db17-4d78-80dd-4b232dab5880.html">粤ICP备15114843号-1</a></p>
     </div>
</template>

<script>
  export default {
    name: 'MainFooter'
  }
</script>

<style scoped>
.el-footer{
   height:auto !important;
   background-color: #363636;
   padding:20px;
}
.el-footer ul {
    width: 711px;
    height: 62px;
    margin: 0 auto;
    font-size: 0;
    text-align: center;
    line-height: 62px;
    border-bottom: 1px dashed #fff;
}
.el-footer ul li, .el-footer ul li a {
    display: inline-block;
}
.el-footer ul li a {
    height: 18px;
    padding: 0 18px;
    line-height: 18px;
    font-size: 14px;
    color: #fff;
}
.el-footer ul li:after {
    content: '|';
    font-size: 18px;
    color: #fff;
}
.el-footer ul li:last-child:after {
    content: '';
    font-size: 18px;
    color: #fff;
}
.el-footer .copyright{
  text-align:center;
  color:#fff;
  margin:20px auto;
  font-size:14px;
}
.el-footer .copyright a{
  color:#fff;
}
</style>