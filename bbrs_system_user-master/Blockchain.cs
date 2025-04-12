using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbrs_system_user
{
    public class Blockchain
    {
        Block GenesisBlock {  get; set; }
        public IList<Block> Chain = new List<Block>();
        public void InitializeChain()
        {
            Chain = new List<Block>();
            AddGenesisBlock();
        }
        public void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock());
        }
        private Block CreateGenesisBlock()
        {
            Block block = new Block(DateTime.Now,null,"0");
            block.Hash_ = block.CreateHash();
            return block;
        }
        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }
        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.id = (latestBlock.id)+1;
            block.PreviousHash = latestBlock.Hash_;
            block.Hash_ = block.CreateHash();
            Chain.Add(block);
        }
        public bool IsValid()
        {
            for (int i =1; i < Chain.Count; i++) 
            {
                Block currentBlock = Chain[i];
                Block prevBlock = Chain[i-1];

                if (currentBlock.Hash_!= currentBlock.CreateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != prevBlock.Hash_)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
