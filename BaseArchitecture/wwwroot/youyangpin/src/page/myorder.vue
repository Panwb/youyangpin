 <template>

</template>
<script>
export default {
  name: 'Myorder',
  data () {
    return {
      activeName: 'order1',
      tableData: [{
            shopname: '王小二的店铺',
            userid: 'cutemantou',
            userphone: '18825815552',
            orderid:'123456',
            orderstate:'已完成',
            planstate:'开始执行',
            shopinfo:"商品信息",
            option:"操作"
          }]
    }
  },
  methods: {
	handleSelect(key, keyPath) {
	  console.log(key, keyPath);
	},
	handleClick(tab, event) {
      console.log(tab, event);
    }
  }
}
</script>